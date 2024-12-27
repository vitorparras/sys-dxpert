

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { RelatorioRoutingModule } from './relatorio-routing.module';

import { RelatorioComponent } from './relatorio.component';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { GerandoRelatorioComponent } from './gerando-relatorio/gerando-relatorio.component';
import { RelatorioCompletoComponent } from './relatorio-completo/relatorio-completo.component';
import { RelatorioGeradoSucessoComponent } from './relatorio-gerado-sucesso/relatorio-gerado-sucesso.component';
import { ProtecaoCustosComponent } from './relatorio-completo/components/protecao-custos/protecao-custos.component';
import { RelatorioCalculoPrevidenciarioComponent } from './relatorio-completo/components/relatorio-calculo-previdenciario/relatorio-calculo-previdenciario.component';
import { RelatorioDadosPessoaisComponent } from './relatorio-completo/components/relatorio-dados-pessoais/relatorio-dados-pessoais.component';
import { RelatorioDidComponent } from './relatorio-completo/components/relatorio-did/relatorio-did.component';
import { RelatorioPercasComponent } from './relatorio-completo/components/relatorio-percas/relatorio-percas.component';
import { RelatorioProdutosComponent } from './relatorio-completo/components/relatorio-produtos/relatorio-produtos.component';
import { RelatorioSugestaoParaRecuperarComponent } from './relatorio-completo/components/relatorio-sugestao-para-recuperar/relatorio-sugestao-para-recuperar.component';
import { RelatorioTermLifeComponent } from './relatorio-completo/components/relatorio-term-life/relatorio-term-life.component';

@NgModule({
  declarations: [
    RelatorioComponent,
    RelatorioCompletoComponent,
    RelatorioGeradoSucessoComponent,
    GerandoRelatorioComponent,


    ProtecaoCustosComponent,
    RelatorioCalculoPrevidenciarioComponent,
    RelatorioDadosPessoaisComponent,
    RelatorioDidComponent,
    RelatorioPercasComponent,
    RelatorioProdutosComponent,
    RelatorioSugestaoParaRecuperarComponent,
    RelatorioTermLifeComponent,
    
  ],
  imports: [
    CommonModule,
    RelatorioRoutingModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    FormsModule,
  ],
  providers: [
  ]
})

export class RelatorioModule { }
