import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
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

interface PasswordStrength {
  hasMinLength: boolean;
  hasUpperCase: boolean;
  hasLowerCase: boolean;
  hasNumber: boolean;
  hasSpecialChar: boolean;
}

@Component({
  selector: 'app-my-user',
  templateUrl: './my-user.component.html',
  styleUrls: ['./my-user.component.scss']
})
export class MyUserComponent implements OnInit {
  profileForm: FormGroup;
  passwordForm: FormGroup;
  notificationForm: FormGroup;

  passwordStrength: PasswordStrength = {
    hasMinLength: false,
    hasUpperCase: false,
    hasLowerCase: false,
    hasNumber: false,
    hasSpecialChar: false
  };

  hideCurrentPassword = true;
  hideNewPassword = true;
  hideConfirmPassword = true;
  isLoading = false;
  isProfileSaving = false;
  isPasswordSaving = false;
  isNotificationsSaving = false;

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
    this.profileForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required]],
      cpf: ['', [Validators.required]],
      insuranceCode: ['', [Validators.required]],
      department: ['', [Validators.required]]
    });

    this.passwordForm = this.fb.group({
      currentPassword: ['', [Validators.required]],
      newPassword: ['', [
        Validators.required,
        Validators.minLength(8),
        this.createPasswordStrengthValidator()
      ]],
      confirmPassword: ['', [Validators.required]]
    }, { validators: this.passwordMatchValidator });

    this.notificationForm = this.fb.group({
      emailNotifications: [true],
      smsNotifications: [false],
      weeklyReport: [true],
      monthlyReport: [true],
      newPolicyAlert: [true],
      renewalReminders: [true]
    });
  }

  ngOnInit() {
    this.loadUserData();
    this.setupFormMasks();
    this.setupPasswordStrengthCheck();
  }

  private setupFormMasks() {
    const phoneControl = this.profileForm.get('phone');
    phoneControl?.valueChanges.subscribe(value => {
      if (!value) return;
      
      let numbers = value.replace(/\D/g, '');
      numbers = numbers.substring(0, 11);
      
      let formatted = '';
      if (numbers.length > 0) {
        formatted = '(' + numbers.substring(0, 2);
        if (numbers.length > 2) {
          formatted += ') ';
          if (numbers.length <= 7) {
            formatted += numbers.substring(2);
          } else {
            formatted += numbers.substring(2, 7) + '-' + numbers.substring(7);
          }
        }
      }
      
      if (numbers.length === 11) {
        phoneControl.setValue(formatted, { emitEvent: false });
        phoneControl.setErrors(null);
      } else {
        phoneControl.setErrors({ pattern: true });
      }
    });

    const cpfControl = this.profileForm.get('cpf');
    cpfControl?.valueChanges.subscribe(value => {
      if (!value) return;
      
      let numbers = value.replace(/\D/g, '');
      numbers = numbers.substring(0, 11);
      
      let formatted = '';
      if (numbers.length > 0) {
        formatted = numbers.substring(0, 3);
        if (numbers.length > 3) {
          formatted += '.' + numbers.substring(3, 6);
          if (numbers.length > 6) {
            formatted += '.' + numbers.substring(6, 9);
            if (numbers.length > 9) {
              formatted += '-' + numbers.substring(9);
            }
          }
        }
      }
      
      if (numbers.length === 11) {
        cpfControl.setValue(formatted, { emitEvent: false });
        cpfControl.setErrors(null);
      } else {
        cpfControl.setErrors({ pattern: true });
      }
    });
  }

  private setupPasswordStrengthCheck() {
    const passwordControl = this.passwordForm.get('newPassword');
    passwordControl?.valueChanges.subscribe(password => {
      if (!password) {
        this.resetPasswordStrength();
        return;
      }

      this.passwordStrength = {
        hasMinLength: password.length >= 8,
        hasUpperCase: /[A-Z]/.test(password),
        hasLowerCase: /[a-z]/.test(password),
        hasNumber: /[0-9]/.test(password),
        hasSpecialChar: /[!@#$%^&*(),.?":{}|<>]/.test(password)
      };
    });

    this.passwordForm.get('confirmPassword')?.valueChanges.subscribe(() => {
      this.passwordForm.get('confirmPassword')?.updateValueAndValidity();
    });
  }

  private resetPasswordStrength() {
    this.passwordStrength = {
      hasMinLength: false,
      hasUpperCase: false,
      hasLowerCase: false,
      hasNumber: false,
      hasSpecialChar: false
    };
  }

  private createPasswordStrengthValidator() {
    return (control: AbstractControl): {[key: string]: any} | null => {
      const value = control.value;
      if (!value) return null;

      const hasUpperCase = /[A-Z]/.test(value);
      const hasLowerCase = /[a-z]/.test(value);
      const hasNumeric = /[0-9]/.test(value);
      const hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(value);
      const hasMinLength = value.length >= 8;

      const passwordValid = hasUpperCase && hasLowerCase && hasNumeric && hasSpecialChar && hasMinLength;

      return !passwordValid ? { passwordStrength: true } : null;
    }
  }

  private passwordMatchValidator(group: FormGroup) {
    const newPassword = group.get('newPassword')?.value;
    const confirmPassword = group.get('confirmPassword')?.value;
    
    if (!newPassword || !confirmPassword) {
      return null;
    }
    
    return newPassword === confirmPassword ? null : { passwordMismatch: true };
  }

  passwordsMatch(): boolean {
    const newPassword = this.passwordForm.get('newPassword')?.value;
    const confirmPassword = this.passwordForm.get('confirmPassword')?.value;
    return newPassword === confirmPassword && newPassword !== '' && confirmPassword !== '';
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
      this.isProfileSaving = true;
      this.userService.updateUser(this.profileForm.value).subscribe({
        next: () => {
          this.showMessage('Perfil atualizado com sucesso!', 'success');
          this.isProfileSaving = false;
        },
        error: () => {
          this.showMessage('Erro ao atualizar perfil', 'error');
          this.isProfileSaving = false;
        }
      });
    } else {
      this.profileForm.markAllAsTouched();
    }
  }

  onUpdatePassword() {
    if (this.passwordForm.valid) {
      this.isPasswordSaving = true;
      const { currentPassword, newPassword } = this.passwordForm.value;
      this.userService.changePassword(currentPassword, newPassword).subscribe({
        next: () => {
          this.showMessage('Senha atualizada com sucesso!', 'success');
          this.passwordForm.reset();
          this.resetPasswordStrength();
          this.isPasswordSaving = false;
        },
        error: () => {
          this.showMessage('Erro ao atualizar senha', 'error');
          this.isPasswordSaving = false;
        }
      });
    } else {
      this.passwordForm.markAllAsTouched();
    }
  }

  onUpdateNotifications() {
    if (this.notificationForm.valid) {
      this.isNotificationsSaving = true;
      setTimeout(() => {
        this.showMessage('Preferências de notificação atualizadas!', 'success');
        this.isNotificationsSaving = false;
      }, 1000);
    }
  }

  toggleNotification(control: string) {
    const currentValue = this.notificationForm.get(control)?.value;
    this.notificationForm.patchValue({ [control]: !currentValue });
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
    if (field.hasError('passwordMismatch')) return 'As senhas não conferem';
    
    return 'Campo inválido';
  }
}

