import { Component, OnInit } from '@angular/core';
import * as bootstrap from 'bootstrap';
import { CadastroService } from 'src/app/services/cadastro.service';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-acompanhamentos',
  templateUrl: './acompanhamentos.component.html',
  styleUrls: ['./acompanhamentos.component.css']
})
export class AcompanhamentosComponent implements OnInit {
  Acompanhamentos: any[] = [];

  constructor(private cadastroService: CadastroService) {}

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(): void {
    this.cadastroService.getAcompanhamentos().subscribe(
      (data) => (this.Acompanhamentos = data),
      (error) => console.error(error)
    );
  }

  openEditUserModal(userId: number): void {
    var exist = document.getElementById('editUserModal');
    if (exist != null) {
      const add = new bootstrap.Modal(exist, {});
      add.show();
    }
  }
}
