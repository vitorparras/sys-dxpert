import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './components/login/login.component';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { EstatisticasComponent } from './components/dashboard/estatisticas/estatisticas.component';
import { UsuariosComponent } from './components/dashboard/usuarios/usuarios.component';
import { MeuUsuarioComponent } from './components/dashboard/meu-usuario/meu-usuario.component';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AddUpdateUserComponent } from './components/dashboard/usuarios/add-update-user/add-update-user.component';


import { TokenInterceptor } from './services/interceptors/token.interceptor';

import { IConfig, NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import {A11yModule} from '@angular/cdk/a11y';
import {CdkAccordionModule} from '@angular/cdk/accordion';
import {ClipboardModule} from '@angular/cdk/clipboard';
import {DragDropModule} from '@angular/cdk/drag-drop';
import {CdkListboxModule} from '@angular/cdk/listbox';
import {PortalModule} from '@angular/cdk/portal';
import {ScrollingModule} from '@angular/cdk/scrolling';
import {CdkStepperModule} from '@angular/cdk/stepper';
import {CdkTableModule} from '@angular/cdk/table';
import {CdkTreeModule} from '@angular/cdk/tree';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatBadgeModule} from '@angular/material/badge';
import {MatBottomSheetModule} from '@angular/material/bottom-sheet';
import {MatButtonModule} from '@angular/material/button';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatCardModule} from '@angular/material/card';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatChipsModule} from '@angular/material/chips';
import {MatStepperModule} from '@angular/material/stepper';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatDialogModule} from '@angular/material/dialog';
import {MatDividerModule} from '@angular/material/divider';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import {MatListModule} from '@angular/material/list';
import {MatMenuModule} from '@angular/material/menu';
import {MatNativeDateModule, MatRippleModule} from '@angular/material/core';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatRadioModule} from '@angular/material/radio';
import {MatSelectModule} from '@angular/material/select';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatSliderModule} from '@angular/material/slider';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatSortModule} from '@angular/material/sort';
import {MatTableModule} from '@angular/material/table';
import {MatTabsModule} from '@angular/material/tabs';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatTreeModule} from '@angular/material/tree';
import {OverlayModule} from '@angular/cdk/overlay';
import {CdkMenuModule} from '@angular/cdk/menu';
import {DialogModule} from '@angular/cdk/dialog';
import { SimulacoesComponent } from './components/dashboard/simulacoes/simulacoes.component';
import { ConfiguracoesComponent } from './components/dashboard/configuracoes/configuracoes.component';
import { CadastroMainComponent } from './components/dxpert/cadastro/inicial/cadastro-main/cadastro-main.component';
import { DadosDescendentesComponent } from './components/dxpert/cadastro/inicial/dados-descendentes/dados-descendentes.component';
import { DadosFinanceirosComponent } from './components/dxpert/cadastro/inicial/dados-financeiros/dados-financeiros.component';
import { DadosSaudeComponent } from './components/dxpert/cadastro/inicial/dados-saude/dados-saude.component';
import { RelatorioGeradoSucessoComponent } from './components/dxpert/relatorio/inicial/relatorio-gerado-sucesso/relatorio-gerado-sucesso.component';
import { RelatorioMainComponent } from './components/dxpert/relatorio/inicial/relatorio-main/relatorio-main.component';
import { RelatorioCompletoComponent } from './components/dxpert/relatorio/inicial/relatorio-completo/relatorio-completo.component';
import { RelatorioCinzaCompletoComponent } from './components/dxpert/relatorio/cinza/relatorio-cinza-completo/relatorio-cinza-completo.component';
import { RelatorioCinzaMainComponent } from './components/dxpert/relatorio/cinza/relatorio-cinza-main/relatorio-cinza-main.component';
import { BeneficiariosComponent } from './components/dxpert/cadastro/cinza/beneficiarios/beneficiarios.component';
import { CinzaMainComponent } from './components/dxpert/cadastro/cinza/cinza-main/cinza-main.component';
import { DadosFiscaisComponent } from './components/dxpert/cadastro/cinza/dados-fiscais/dados-fiscais.component';
import { DeclaracaoPessoalComponent } from './components/dxpert/cadastro/cinza/declaracao-pessoal/declaracao-pessoal.component';
import { DocumentacaoComponent } from './components/dxpert/cadastro/cinza/documentacao/documentacao.component';
import { EnderecoResidencialComponent } from './components/dxpert/cadastro/cinza/endereco-residencial/endereco-residencial.component';
import { FormaPagamentoComponent } from './components/dxpert/cadastro/cinza/forma-pagamento/forma-pagamento.component';
import { SaudeAtividadeComponent } from './components/dxpert/cadastro/cinza/saude-atividade/saude-atividade.component';
import { DadosFamiliaresComponent } from './components/dxpert/cadastro/inicial/dados-familiares/dados-familiares.component';
import { DadosPessoaisComponent } from './components/dxpert/cadastro/inicial/dados-pessoais/dados-pessoais.component';
import { DadosProfissionaisComponent } from './components/dxpert/cadastro/inicial/dados-profissionais/dados-profissionais.component';
import { AcompanhamentosComponent } from './components/dashboard/acompanhamentos/acompanhamentos.component';

import { CurrencyMaskModule } from "ng2-currency-mask";
import { RelatorioDadosPessoaisComponent } from './components/dxpert/relatorio/inicial/relatorio-completo/components/relatorio-dados-pessoais/relatorio-dados-pessoais.component';
import { RelatorioCalculoPrevidenciarioComponent } from './components/dxpert/relatorio/inicial/relatorio-completo/components/relatorio-calculo-previdenciario/relatorio-calculo-previdenciario.component';
import { RelatorioPercasComponent } from './components/dxpert/relatorio/inicial/relatorio-completo/components/relatorio-percas/relatorio-percas.component';
import { RelatorioSugestaoParaRecuperarComponent } from './components/dxpert/relatorio/inicial/relatorio-completo/components/relatorio-sugestao-para-recuperar/relatorio-sugestao-para-recuperar.component';
import { CurrencyPipe } from '@angular/common';

import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';

registerLocaleData(localePt);

import { NgChartsModule  } from 'ng2-charts';
import { RelatorioTermLifeComponent } from './components/dxpert/relatorio/inicial/relatorio-completo/components/relatorio-term-life/relatorio-term-life.component';
import { RelatorioProdutosComponent } from './components/dxpert/relatorio/inicial/relatorio-completo/components/relatorio-produtos/relatorio-produtos.component';
import { RelatorioDidComponent } from './components/dxpert/relatorio/inicial/relatorio-completo/components/relatorio-did/relatorio-did.component';
import { ProtecaoCustosComponent } from './components/dxpert/relatorio/inicial/relatorio-completo/components/protecao-custos/protecao-custos.component';
import { DecimalPipe } from '@angular/common';
import { ComponentsModule } from './components/dashboard/shared/components.module';
import { GerandoRelatorioComponent } from './components/dxpert/relatorio/inicial/gerando-relatorio/gerando-relatorio.component';
import { IndexComponent } from './components/dashboard/index/index.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    IndexComponent,
    EstatisticasComponent,

    //usuarios
    UsuariosComponent,
    MeuUsuarioComponent,
    AddUpdateUserComponent,
    DadosPessoaisComponent,
    DadosFamiliaresComponent,
    DadosDescendentesComponent,
    DadosProfissionaisComponent,
    DadosFinanceirosComponent,
    DadosSaudeComponent,
    GerandoRelatorioComponent,
    RelatorioMainComponent,
    DocumentacaoComponent,
    DadosFiscaisComponent,
    EnderecoResidencialComponent,
    BeneficiariosComponent,
    FormaPagamentoComponent,
    DeclaracaoPessoalComponent,
    SaudeAtividadeComponent,
    CinzaMainComponent,
    CadastroMainComponent,
    SimulacoesComponent,
    RelatorioGeradoSucessoComponent,
    ConfiguracoesComponent,
    RelatorioCompletoComponent,
    RelatorioCinzaCompletoComponent,
    RelatorioCinzaMainComponent,
    AcompanhamentosComponent,
    RelatorioDadosPessoaisComponent,
    RelatorioCalculoPrevidenciarioComponent,
    RelatorioPercasComponent,
    RelatorioSugestaoParaRecuperarComponent,
    RelatorioTermLifeComponent,
    RelatorioProdutosComponent,
    RelatorioDidComponent,
    ProtecaoCustosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatToolbarModule,
    MatButtonModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    ComponentsModule,
    FontAwesomeModule,
    HttpClientModule,
    MatGridListModule,
    MatCardModule,
    MatSidenavModule,
    MatSnackBarModule,
    NgxMaskDirective,
    NgxMaskPipe,
    A11yModule,
    CdkAccordionModule,
    ClipboardModule,
    CdkListboxModule,
    CdkMenuModule,
    CdkStepperModule,
    CdkTableModule,
    CdkTreeModule,
    DragDropModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
    OverlayModule,
    PortalModule,
    ScrollingModule,
    DialogModule,
    CurrencyMaskModule,
    NgChartsModule,
  ],
  exports: [
    A11yModule,
    CdkAccordionModule,
    ClipboardModule,
    CdkListboxModule,
    CdkMenuModule,
    CdkStepperModule,
    CdkTableModule,
    CdkTreeModule,
    DragDropModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
    OverlayModule,
    PortalModule,
    ScrollingModule,
    DialogModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true},
    provideNgxMask(),
    CurrencyPipe,
    DecimalPipe,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

