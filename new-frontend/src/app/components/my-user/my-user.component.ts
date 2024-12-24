import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-my-user',
  templateUrl: './my-user.component.html',
  styleUrls: ['./my-user.component.scss']
})
export class MyUserComponent implements OnInit {
  userForm: FormGroup;
  passwordForm: FormGroup;
  currentUser: any;

  constructor(
    private fb: FormBuilder,
    private userService: UserService
  ) {
    this.userForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });

    this.passwordForm = this.fb.group({
      currentPassword: ['', Validators.required],
      newPassword: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    }, { validator: this.checkPasswords });
  }

  ngOnInit() {
    this.loadCurrentUser();
  }

  loadCurrentUser() {
    this.userService.getCurrentUser().subscribe(user => {
      this.currentUser = user;
      this.userForm.patchValue({
        name: user.name,
        email: user.email
      });
    });
  }

  onSubmitUserForm() {
    if (this.userForm.valid) {
      const updatedUser = { ...this.currentUser, ...this.userForm.value };
      this.userService.updateUser(updatedUser).subscribe(() => {
        alert('Informações atualizadas com sucesso!');
      });
    }
  }

  onSubmitPasswordForm() {
    if (this.passwordForm.valid) {
      const { currentPassword, newPassword } = this.passwordForm.value;
      this.userService.changePassword(currentPassword, newPassword).subscribe(() => {
        alert('Senha alterada com sucesso!');
        this.passwordForm.reset();
      });
    }
  }

  checkPasswords(group: FormGroup) {
    const newPassword = group.get('newPassword')?.value;
    const confirmPassword = group.get('confirmPassword')?.value;
    return newPassword === confirmPassword ? null : { notSame: true };
  }
}

