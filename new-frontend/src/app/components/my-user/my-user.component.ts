import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserService } from '../../services/user.service';

interface UserMetrics {
  totalSales: number;
  policiesSold: number;
  conversionRate: number;
  customerRetention: number;
  averageTicket: number;
  ranking: number;
}

@Component({
  selector: 'app-my-user',
  templateUrl: './my-user.component.html',
  styleUrls: ['./my-user.component.scss']
})
export class MyUserComponent implements OnInit {
  profileForm: FormGroup = this.fb.group({
    name: ['', [Validators.required, Validators.minLength(3)]],
    email: ['', [Validators.required, Validators.email]],
    phone: ['', [Validators.required, Validators.pattern(/^$$\d{2}$$ \d{5}-\d{4}$/)]],
    cpf: ['', [Validators.required, Validators.pattern(/^\d{3}\.\d{3}\.\d{3}-\d{2}$/)]],
    insuranceCode: ['', [Validators.required]],
    department: ['', [Validators.required]]
  });

  passwordForm: FormGroup = this.fb.group({
    currentPassword: ['', [Validators.required]],
    newPassword: ['', [Validators.required, Validators.minLength(8)]],
    confirmPassword: ['', [Validators.required]]
  }, { validator: this.passwordMatchValidator });

  notificationForm: FormGroup = this.fb.group({
    emailNotifications: [true],
    smsNotifications: [false],
    weeklyReport: [true],
    monthlyReport: [true],
    newPolicyAlert: [true],
    renewalReminders: [true]
  });
  isLoading = false;
  userMetrics: UserMetrics = {
    totalSales: 450000,
    policiesSold: 127,
    conversionRate: 68,
    customerRetention: 92,
    averageTicket: 3543,
    ranking: 3
  };

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private snackBar: MatSnackBar
  ) {
   
  }

  ngOnInit() {
    this.loadUserData();
  }


  private loadUserData() {
    this.isLoading = true;
    this.userService.getCurrentUser().subscribe({
      next: (user) => {
        this.profileForm.patchValue({
          name: 'John Doe',
          email: 'john@example.com',
          phone: '(11) 98765-4321',
          cpf: '123.456.789-00',
          insuranceCode: 'INS123456',
          department: 'Vendas'
        });
        this.isLoading = false;
      },
      error: (error) => {
        this.showMessage('Erro ao carregar dados do usuário', 'error');
        this.isLoading = false;
      }
    });
  }

  onUpdateProfile() {
    if (this.profileForm.valid) {
      this.isLoading = true;
      this.userService.updateUser(this.profileForm.value).subscribe({
        next: () => {
          this.showMessage('Perfil atualizado com sucesso!', 'success');
          this.isLoading = false;
        },
        error: () => {
          this.showMessage('Erro ao atualizar perfil', 'error');
          this.isLoading = false;
        }
      });
    } else {
      this.profileForm.markAllAsTouched();
    }
  }

  onUpdatePassword() {
    if (this.passwordForm.valid) {
      this.isLoading = true;
      const { currentPassword, newPassword } = this.passwordForm.value;
      this.userService.changePassword(currentPassword, newPassword).subscribe({
        next: () => {
          this.showMessage('Senha atualizada com sucesso!', 'success');
          this.passwordForm.reset();
          this.isLoading = false;
        },
        error: () => {
          this.showMessage('Erro ao atualizar senha', 'error');
          this.isLoading = false;
        }
      });
    } else {
      this.passwordForm.markAllAsTouched();
    }
  }

  onUpdateNotifications() {
    if (this.notificationForm.valid) {
      this.isLoading = true;
      // Simulate API call
      setTimeout(() => {
        this.showMessage('Preferências de notificação atualizadas!', 'success');
        this.isLoading = false;
      }, 1000);
    }
  }

  private passwordMatchValidator(group: FormGroup) {
    const newPassword = group.get('newPassword')?.value;
    const confirmPassword = group.get('confirmPassword')?.value;
    return newPassword === confirmPassword ? null : { passwordMismatch: true };
  }

  private showMessage(message: string, type: 'success' | 'error') {
    this.snackBar.open(message, 'Fechar', {
      duration: 5000,
      horizontalPosition: 'right',
      verticalPosition: 'top',
      panelClass: type === 'success' ? ['success-snackbar'] : ['error-snackbar']
    });
  }

  getErrorMessage(control: string, form: FormGroup = this.profileForm): string {
    const field = form.get(control);
    
    if (!field?.errors) return '';
    
    if (field.hasError('required')) return 'Campo obrigatório';
    if (field.hasError('email')) return 'Email inválido';
    if (field.hasError('minlength')) {
      const minLength = field.errors?.['minlength'].requiredLength;
      return `Mínimo de ${minLength} caracteres`;
    }
    if (field.hasError('pattern')) {
      if (control === 'phone') return 'Formato: (99) 99999-9999';
      if (control === 'cpf') return 'Formato: 999.999.999-99';
    }
    if (field.hasError('passwordMismatch')) return 'Senhas não conferem';
    
    return 'Campo inválido';
  }
}

