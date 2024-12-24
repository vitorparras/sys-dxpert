import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CadastroService } from 'src/app/services/cadastro.service';
import { localStorageVarNames } from 'src/environments/localStorageVarNames';
@Component({
  selector: 'app-simulacoes',
  templateUrl: './simulacoes.component.html',
  styleUrls: ['./simulacoes.component.css']
})
export class SimulacoesComponent {
  cads: any[] = [];
  selectedName: string = '';

  constructor(private cadastroService: CadastroService, private router: Router) {}

  ngOnInit(): void {
    this.getCads();
  }

  get selectedUserId(): number {
    return this._selectedUserId;
  }

  set selectedUserId(value: number) {
    this._selectedUserId = value;
  }

  private _selectedUserId: number = 0;

  getCads(): void {
    this.cadastroService.list().subscribe(
      (data) => (this.cads = data.cadastros),
      (error) => console.error(error)
    );
  }

  add(): void {
    this.router.navigate(['/cadastro/dados-pessoais']);
  }

  continuarCadastro(cadId:any): void {
    localStorage.setItem(localStorageVarNames.IdCadastroAtual , cadId.toString());
    this.router.navigate(['/relatorioCompleto']);
  }
}
