import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RelatorioComponent } from './relatorio.component';

import { DadosPessoaisComponent } from './steps/dados-pessoais/dados-pessoais.component';
import { DadosDescendentesComponent } from './steps/dados-descendentes/dados-descendentes.component';
import { DadosProfissionaisComponent } from './steps/dados-profissionais/dados-profissionais.component';
import { DadosFinanceirosComponent } from './steps/dados-financeiros/dados-financeiros.component';
import { DadosSaudeComponent } from './steps/dados-saude/dados-saude.component';
import { DadosFamiliaresComponent } from './steps/dados-familiares/dados-familiares.component';

const routes: Routes = [
  {path: '', component: RelatorioComponent},
  { path: 'cadastro', component: RelatorioComponent,
    children: [
      { path: 'dados-pessoais', component: DadosPessoaisComponent },
      { path: 'dados-familiares', component: DadosFamiliaresComponent },
      { path: 'dados-descendentes', component: DadosDescendentesComponent },
      { path: 'dados-profissionais', component: DadosProfissionaisComponent },
      { path: 'dados-financeiros', component: DadosFinanceirosComponent },
      { path: 'dados-saude', component: DadosSaudeComponent }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RelatorioRoutingModule { }