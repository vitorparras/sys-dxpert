import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { User } from '../../../../services/user.service';

@Component({
  selector: 'app-user-dialog',
  templateUrl: './user-dialog.component.html',
  styleUrls: ['./user-dialog.component.scss']
})
export class UserDialogComponent implements OnInit {
  userForm: FormGroup;
  isEditMode: boolean;
  avatarUrl: string = '';

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<UserDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: User
  ) {
    this.isEditMode = !!data.id;
    this.userForm = this.fb.group({
      name: [data.name || '', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      email: [data.email || '', [Validators.required, Validators.email]],
      phone: [data.phone || '', [Validators.required, Validators.pattern(/^$$\d{2}$$\s\d{5}-\d{4}$/)]],
      role: [data.role || 'user', Validators.required]
    });
    this.updateAvatarUrl();
  }

  ngOnInit() {
    this.updateAvatarUrl();
    this.userForm.get('name')?.valueChanges.subscribe(() => {
      this.updateAvatarUrl();
    });
  }

  updateAvatarUrl() {
    const name = this.userForm.get('name')?.value || 'User';
    this.avatarUrl = `https://ui-avatars.com/api/?name=${encodeURIComponent(name)}&background=random&color=fff`;
  }

  onSubmit() {
    if (this.userForm.valid) {
      this.dialogRef.close({
        ...this.data,
        ...this.userForm.value
      });
    } else {
      this.userForm.markAllAsTouched();
    }
  }

  onCancel() {
    this.dialogRef.close();
  }

  getErrorMessage(controlName: string): string {
    const control = this.userForm.get(controlName);
    if (control?.hasError('required')) {
      return 'This field is required';
    }
    if (control?.hasError('email')) {
      return 'Invalid email format';
    }
    if (control?.hasError('minlength')) {
      return `Minimum length is ${control.errors?.['minlength'].requiredLength} characters`;
    }
    if (control?.hasError('maxlength')) {
      return `Maximum length is ${control.errors?.['maxlength'].requiredLength} characters`;
    }
    if (control?.hasError('pattern')) {
      return 'Invalid phone format. Use (XX) XXXXX-XXXX';
    }
    return '';
  }
}

