import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SystemSettingsService } from '../../../../services/system-settings.service';
import { SystemSetting, SettingCategory } from '../../../../interfaces/system-settings.interface';
import { SettingsDialogComponent } from '../settings-dialog/settings-dialog.component';
import { ConfirmDialogComponent } from '../../../shared/confirm-dialog/confirm-dialog.component';
import { FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { MatButtonToggleChange } from '@angular/material/button-toggle';

@Component({
  selector: 'app-system-settings',
  templateUrl: './system-settings.component.html',
  styleUrls: ['./system-settings.component.scss']
})
export class SystemSettingsComponent implements OnInit {
  settings: SystemSetting[] = [];
  filteredSettings: SystemSetting[] = [];
  categories: SettingCategory[] = ['general', 'email', 'security', 'integration'];
  selectedCategory: SettingCategory | 'all' = 'all';
  searchControl = new FormControl('');
  isLoading = true;

  constructor(
    private systemSettingsService: SystemSettingsService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit() {
    this.loadSettings();
    this.setupSearch();
  }

  private setupSearch() {
    this.searchControl.valueChanges.pipe(
      debounceTime(300),
      distinctUntilChanged()
    ).subscribe(value => {
      this.filterSettings(value || '');
    });
  }

  private loadSettings() {
    this.isLoading = true;
    this.systemSettingsService.getSettings().subscribe({
      next: (settings) => {
        this.settings = settings;
        this.filterSettings(this.searchControl.value || '');
        this.isLoading = false;
      },
      error: () => {
        this.showMessage('Erro ao carregar configurações', 'error');
        this.isLoading = false;
      }
    });
  }

  filterSettings(searchTerm: string) {
    let filtered = this.settings;
    
    // Filter by category
    if (this.selectedCategory !== 'all') {
      filtered = filtered.filter(setting => setting.category === this.selectedCategory);
    }

    // Filter by search term
    if (searchTerm) {
      const term = searchTerm.toLowerCase();
      filtered = filtered.filter(setting => 
        setting.label.toLowerCase().includes(term) ||
        setting.key.toLowerCase().includes(term) ||
        setting.description.toLowerCase().includes(term)
      );
    }

    this.filteredSettings = filtered;
  }

  onCategoryChange(event: MatButtonToggleChange) {
    this.selectedCategory = event.value;
    this.filterSettings(this.searchControl.value || '');
  }

  openSettingsDialog(setting?: SystemSetting) {
    const dialogRef = this.dialog.open(SettingsDialogComponent, {
      width: '600px',
      data: setting || {}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        if (result.id) {
          this.updateSetting(result);
        } else {
          this.addSetting(result);
        }
      }
    });
  }

  private addSetting(setting: Omit<SystemSetting, 'id'>) {
    this.systemSettingsService.addSetting(setting).subscribe({
      next: () => {
        this.loadSettings();
        this.showMessage('Configuração adicionada com sucesso');
      },
      error: () => this.showMessage('Erro ao adicionar configuração', 'error')
    });
  }

  private updateSetting(setting: SystemSetting) {
    this.systemSettingsService.updateSetting(setting).subscribe({
      next: () => {
        this.loadSettings();
        this.showMessage('Configuração atualizada com sucesso');
      },
      error: () => this.showMessage('Erro ao atualizar configuração', 'error')
    });
  }

  deleteSetting(setting: SystemSetting) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '400px',
      data: {
        title: 'Confirmar Exclusão',
        message: `Tem certeza que deseja excluir a configuração "${setting.label}"?`,
        confirmText: 'Excluir',
        cancelText: 'Cancelar'
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.systemSettingsService.deleteSetting(setting.id).subscribe({
          next: () => {
            this.loadSettings();
            this.showMessage('Configuração excluída com sucesso');
          },
          error: () => this.showMessage('Erro ao excluir configuração', 'error')
        });
      }
    });
  }

  getCategoryIcon(category: SettingCategory): string {
    const icons: Record<SettingCategory, string> = {
      general: 'settings',
      email: 'email',
      security: 'security',
      integration: 'integration_instructions'
    };
    return icons[category];
  }

  getCategoryLabel(category: SettingCategory): string {
    const labels: Record<SettingCategory, string> = {
      general: 'Geral',
      email: 'Email',
      security: 'Segurança',
      integration: 'Integração'
    };
    return labels[category];
  }

  getSettingTypeIcon(type: string): string {
    const icons: Record<string, string> = {
      text: 'text_fields',
      number: 'numbers',
      boolean: 'toggle_on',
      select: 'list'
    };
    return icons[type] || 'help';
  }

  private showMessage(message: string, type: 'success' | 'error' = 'success') {
    this.snackBar.open(message, 'Fechar', {
      duration: 5000,
      horizontalPosition: 'right',
      verticalPosition: 'top',
      panelClass: type === 'success' ? ['success-snackbar'] : ['error-snackbar']
    });
  }
}

