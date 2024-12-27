

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { DadosPessoaisComponent } from './steps/dados-pessoais/dados-pessoais.component';
import { DateMaskDirective } from 'src/app/directives/date-mask.directive';
import { InputMaskDirective } from 'src/app/directives/input-mask.directive';
import { PhoneMaskDirective } from 'src/app/directives/phone-mask.directive';
import { MaskDirective } from 'src/app/directives/mask.directive';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { DadosDescendentesComponent } from './steps/dados-descendentes/dados-descendentes.component';
import { DadosProfissionaisComponent } from './steps/dados-profissionais/dados-profissionais.component';
import { DadosFinanceirosComponent } from './steps/dados-financeiros/dados-financeiros.component';
import { DadosSaudeComponent } from './steps/dados-saude/dados-saude.component';
import { DadosFamiliaresComponent } from './steps/dados-familiares/dados-familiares.component';


import { CadastroComponent } from './cadastro.component';
import { CadastroRoutingModule } from './cadastro-routing.module';

@NgModule({
  declarations: [
    CadastroComponent,
    DadosPessoaisComponent,
    DadosFamiliaresComponent,
    DadosDescendentesComponent,
    DadosProfissionaisComponent,
    DadosFinanceirosComponent,
    DadosSaudeComponent,
    PhoneMaskDirective,
    InputMaskDirective,
    DateMaskDirective,
    MaskDirective
  ],
  imports: [
    CommonModule,
    CadastroRoutingModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    FormsModule,
  ],
  providers: [
  ]
})

export class CadastroModule { }
