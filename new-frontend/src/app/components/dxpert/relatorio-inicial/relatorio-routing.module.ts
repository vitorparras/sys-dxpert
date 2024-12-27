import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RelatorioComponent } from './relatorio.component';
import { GerandoRelatorioComponent } from './gerando-relatorio/gerando-relatorio.component';
import { RelatorioGeradoSucessoComponent } from './relatorio-gerado-sucesso/relatorio-gerado-sucesso.component';
import { RelatorioCompletoComponent } from './relatorio-completo/relatorio-completo.component';



const routes: Routes = [
  { path: '', component: RelatorioComponent },
  {
    path: 'steps', component: RelatorioComponent,
    children: [
      { path: 'gerando', component: GerandoRelatorioComponent },
      { path: 'gerado', component: RelatorioGeradoSucessoComponent },
      { path: 'completo', component: RelatorioCompletoComponent },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RelatorioRoutingModule { }
