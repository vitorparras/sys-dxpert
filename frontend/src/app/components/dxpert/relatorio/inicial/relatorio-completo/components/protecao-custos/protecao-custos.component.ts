import {
  Component,
  Input,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { RelatorioService } from 'src/app/services/relatorio.service';
import { SharedService } from 'src/app/services/shared.service';
import { localStorageVarNames } from 'src/environments/localStorageVarNames';

@Component({
  selector: 'app-protecao-custos',
  templateUrl: './protecao-custos.component.html',
  styleUrls: ['./protecao-custos.component.css'],
})
export class ProtecaoCustosComponent implements OnInit, OnDestroy {
  private typingTimer: any;
  @Input() relatorio: any;
  @ViewChild('inputElement') inputElement: ElementRef | undefined;

  ngOnInit() {
    this.inputElement?.nativeElement?.focus();
  }

  constructor(
    public sharedService: SharedService,
    private _relatorioService: RelatorioService
  ) {}

  onInputKeyUp(element: any) {
    clearTimeout(this.typingTimer);
    this.typingTimer = setTimeout(() => {
      this.ConverteValor(element);
      this.realizarAcao();
    }, 1000);
    this.ConverteValor(element);
  }

  realizarAcao() {
    // Coloque sua lógica aqui para a ação que deseja realizar
    this.RecalcularEvolucao();
  }

  ngOnDestroy() {
    clearTimeout(this.typingTimer);
  }

  beneficiosInvalides = ' R$ _____________________';
  beneficiosMorte = ' R$ _____________________';
  req: any = {
    totalDeCusto: '0.00',
    valorAno1: { idade: '0', valor: '0.00' },
    valorAno2: { idade: '0', valor: '0.00' },
    valorAno3: { idade: '0', valor: '0.00' },
    valorAno4: { idade: '0', valor: '0.00' },
    valorAno5: { idade: '0', valor: '0.00' },
    valorAnoTotal: '0.00',
    valorInvalidez: '0.00',
    valorMorte: '0.00',
  };

  ConverteValor(element: any) {
    let val = element.target.value;
    val = this.sharedService.transformAmount(val);
    element.target.value = val;
  }

  RecalcularEvolucao() {
    var idCad = localStorage.getItem(localStorageVarNames.IdCadastroAtual) ?? 0;
    const beneficiosMorteValor = this.sharedService.transformAmount(this.beneficiosMorte);
    const beneficiosInvalidesValor = this.sharedService.transformAmount(this.beneficiosInvalides);
  
    this._relatorioService
      .getEvolucaoDeCustos(
        Number(idCad),
        beneficiosMorteValor,
        beneficiosInvalidesValor
      )
      .subscribe((res) => {
        console.log(res);
        this.req = res;
      });
  }
}
