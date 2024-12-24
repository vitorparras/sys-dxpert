import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { IUserData, UserResponse } from 'src/app/interfaces/Usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-add-update-user',
  templateUrl: './add-update-user.component.html',
  styleUrls: ['./add-update-user.component.css'],
})
export class AddUpdateUserComponent implements OnInit {

  @Output() userAdded = new EventEmitter<void>();
  @Output() userEdited = new EventEmitter<void>();
  @Output() userReloaded = new EventEmitter<void>();

  @Input() isEditMode: boolean = false;
  @Input() userId: number | null = null;

  public user: IUserData = {
    id: 0,
    nome: '',
    email: '',
    telefone: '',
    permissao: 0,
    senha: '',
    senhaConfirm: '',
  };

  passwordMismatch = false;

  constructor(private userService: UsuarioService) { }

  ngOnInit(): void {
    if (this.userId && this.userId !== 0) {
      this.userService.findUser(this.userId).subscribe(
        (response: UserResponse) => {
          if (response.success) {
            const userData = response.data;
            this.user = {
              ...this.user,
              id: userData.id,
              nome: userData.nome,
              email: userData.email,
              telefone: userData.telefone,
              permissao: userData.permissao,
            };
            this.user.senha = '';
            this.user.senhaConfirm = '';
            this.isEditMode = true;
          } else {
            console.error(response.message);
          }
        },
        (error) => console.error(error)
      );
    } else {
      this.user = {
        id: 0,
        nome: '',
        email: '',
        telefone: '',
        permissao: 0,
        senha: '',
        senhaConfirm: '',
      };
      this.isEditMode = false;
    }
  }


  validatePassword(): void {
    this.passwordMismatch = this.user.senha !== this.user.senhaConfirm;
  }

  addUser(form: NgForm): void {
    if (this.passwordMismatch) {
      return;
    }

    if (this.isEditMode) {
      this.userService.editUser(this.user).subscribe(
        () => {
          this.userEdited.emit();
          this.user.senha = '';
          this.user.senhaConfirm = '';
          this.ngOnInit();
        },
        (error) => console.error(error)
      );
    } else {
      this.userService.addUser(this.user).subscribe(
        () => {
          this.userAdded.emit();
          form.resetForm(); // Reseta o formulário após a adição de um novo usuário
        },
        (error) => console.error(error)
      );
    }
  }
}
