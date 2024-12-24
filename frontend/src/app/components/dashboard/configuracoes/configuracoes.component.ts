import { Component, OnInit } from '@angular/core';
import * as bootstrap from 'bootstrap';
import { ConfiguracaoService } from 'src/app/services/configuracao.service';

@Component({
  selector: 'app-configuracoes',
  templateUrl: './configuracoes.component.html',
  styleUrls: ['./configuracoes.component.css'],
})
export class ConfiguracoesComponent implements OnInit {
  configuracoes: any;
  editIndex: number | null = null;
  editNomeConfig: string | null = null;
  editValueConfig: string | null = null;

  constructor(private service: ConfiguracaoService) {}

  ngOnInit(): void {
    this.service.getAll().subscribe((data) => {
      this.configuracoes = data;
    });
  }

  saveEdit(): void {
    const config = {
      id: this.editIndex,
      Valor: this.editValueConfig,
    };

    this.service.update(config).subscribe(() => {
        this.ngOnInit();
    });
  }

  openEditUserModal(edit: any): void {
    this.editIndex = edit.id;
    this.editNomeConfig = edit.nome;
    this.editValueConfig = edit.valor;

    var exist = document.getElementById('editUserModal');
    if (exist != null) {
      const add = new bootstrap.Modal(exist, {});
      add.show();
    }
  }
}
