import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SystemSettingsService } from '../../services/system-settings.service';
import { SettingsDialogComponent } from '../settings-dialog/settings-dialog.component';

@Component({
  selector: 'app-system-settings',
  templateUrl: './system-settings.component.html',
  styleUrls: ['./system-settings.component.scss']
})
export class SystemSettingsComponent implements OnInit {
  settings: any[] = [];
  displayedColumns: string[] = ['key', 'value', 'actions'];

  constructor(
    private systemSettingsService: SystemSettingsService,
    private dialog: MatDialog
  ) {}

  ngOnInit() {
    this.loadSettings();
  }

  loadSettings() {
    this.systemSettingsService.getSettings().subscribe(settings => {
      this.settings = settings;
    });
  }

  openSettingsDialog(setting?: any) {
    const dialogRef = this.dialog.open(SettingsDialogComponent, {
      width: '400px',
      data: setting || {}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        if (result.id) {
          this.systemSettingsService.updateSetting(result).subscribe(() => {
            this.loadSettings();
          });
        } else {
          this.systemSettingsService.addSetting(result).subscribe(() => {
            this.loadSettings();
          });
        }
      }
    });
  }

  deleteSetting(id: number) {
    if (confirm('Tem certeza que deseja excluir esta configuração?')) {
      this.systemSettingsService.deleteSetting(id).subscribe(() => {
        this.loadSettings();
      });
    }
  }
}

