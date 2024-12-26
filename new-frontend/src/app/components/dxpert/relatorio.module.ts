import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RelatorioRoutingModule } from './relatorio-routing.module';
import { RelatorioComponent } from './relatorio.component';
import { ReactiveFormsModule } from '@angular/forms';
import { DadosPessoaisComponent } from './cadastro/inicial/dados-pessoais/dados-pessoais.component';


@NgModule({
  declarations: [
    RelatorioComponent,
    DadosPessoaisComponent
  ],
  imports: [
    CommonModule,
    RelatorioRoutingModule,
    ReactiveFormsModule
  ]
})

export class RelatorioModule { }
