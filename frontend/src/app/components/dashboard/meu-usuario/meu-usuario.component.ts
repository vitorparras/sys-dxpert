import { Component, OnInit } from '@angular/core';

import { MatDialog } from '@angular/material/dialog';
import { localStorageVarNames } from 'src/environments/localStorageVarNames';

@Component({
  selector: 'app-meu-usuario',
  templateUrl: './meu-usuario.component.html',
  styleUrls: ['./meu-usuario.component.css'],
})
export class MeuUsuarioComponent implements OnInit {
  constructor(public dialog: MatDialog) { }

  get selectedUserId(): number {
    return this._selectedUserId;
  }

  set selectedUserId(value: number) {
    this._selectedUserId = value;
  }

  private _selectedUserId: number = 0;

  ngOnInit() {
    this.reloadUser();
  }

  reloadUser() {
    this.selectedUserId = parseInt(localStorage.getItem(localStorageVarNames.IdUser) ?? '') ?? 0;
  }
}
