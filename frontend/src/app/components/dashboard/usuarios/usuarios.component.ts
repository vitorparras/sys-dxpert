import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario.service';
import * as bootstrap from 'bootstrap';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css'],
})
export class UsuariosComponent implements OnInit {
  users: any[] = [];
  selectedName: string = '';

  constructor(private userService: UsuarioService) {}

  ngOnInit(): void {
    this.getUsers();
  }

  get selectedUserId(): number {
    return this._selectedUserId;
  }

  set selectedUserId(value: number) {
    this._selectedUserId = value;
  }

  private _selectedUserId: number = 0;

  getUsers(): void {
    this.userService.getUsers().subscribe(
      (data) => (this.users = data),
      (error) => console.error(error)
    );
  }

  onUserAdded(): void {
    this.getUsers();
    var elen = document.getElementById('btnfecharModalAdd');
    if (elen != null) elen.click();
  }

  onUserEdited(): void {
    this.getUsers();
    var elen = document.getElementById('btnfecharModalEdit');
    if (elen != null) elen.click();
  }

  confirmDeleteUser(): void {
    this.userService.deleteUser(this.selectedUserId).subscribe(
      () =>
        (this.users = this.users.filter(
          (user) => user.id !== this.selectedUserId
        )),
      (error) => console.error(error)
    );
  }

  openDeleteUserModal(userId: number): void {
    this.selectedUserId = userId;
    this.selectedName = this.users.find((user) => user.id === userId).nome;
    var exist = document.getElementById('deleteUserModal');
    if (exist != null) {
      const deleteUserModal = new bootstrap.Modal(exist, {});
      deleteUserModal.show();
    }
  }

  openEditUserModal(userId: number): void {
    this.selectedUserId = userId;
    this.selectedName = this.users.find((user) => user.id === userId).nome;

    var exist = document.getElementById('editUserModal');
    if (exist != null) {
      const add = new bootstrap.Modal(exist, {});
      add.show();
    }
  }
}
