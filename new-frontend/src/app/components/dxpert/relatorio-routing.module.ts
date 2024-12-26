import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RelatorioComponent } from './relatorio.component';
import { DadosPessoaisComponent } from './cadastro/inicial/dados-pessoais/dados-pessoais.component';

const routes: Routes = [
  {path: '', component: RelatorioComponent},
  { path: 'cadastro', component: RelatorioComponent,
    children: [
      { path: 'dados-pessoais', component: DadosPessoaisComponent },
      //{ path: 'dados-familiares', component: DadosFamiliaresComponent },
      //{ path: 'dados-descendentes', component: DadosDescendentesComponent },
      //{ path: 'dados-profissionais', component: DadosProfissionaisComponent },
      //{ path: 'dados-financeiros', component: DadosFinanceirosComponent },
      //{ path: 'dados-saude', component: DadosSaudeComponent }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RelatorioRoutingModule { }
