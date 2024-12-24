import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoadingService } from 'src/app/services/loading.service';
import { CadastroService } from 'src/app/services/cadastro.service';
import { localStorageVarNames } from 'src/environments/localStorageVarNames';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-dados-financeiros',
  templateUrl: './dados-financeiros.component.html',
  styleUrls: ['./dados-financeiros.component.css'],
})
export class DadosFinanceirosComponent {
  form!: FormGroup;
  err: string | undefined;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    public loadingService: LoadingService,
    private _cadastroService: CadastroService,
    private _sharedService: SharedService
  ) {}

  ngOnInit() {
    this.form = this.fb.group({
      impostoDeRenda: [''],
      rendaBruta: [''],
      despesaMensal: [''],
      reservaEmergencia: [''],
      tempoReserva: [''],
      etapa: 'Dados Financeiros',
      id: 0,
    });
  }

  enviar() {
    this.loadingService.show();
    var idCad = localStorage.getItem(localStorageVarNames.IdCadastroAtual);
    this.form.get('id')?.setValue(idCad);

    if (this.form.valid) {
      this._cadastroService.edit(this.form.value).subscribe(
        (res) => {
          if (res.sucesso) {
            setTimeout(() => {
              this.loadingService.hide();
              this.router.navigate(['/cadastro/dados-saude']);
            }, 1000);
          } else {
            this.err = res.Message;
            this.loadingService.hide();
          }
        },
        (err) => {
          this.err = err;
          this.loadingService.hide();
        }
      );
    } else {
      this.err = 'Formulario Com campos invalidos';
      this.loadingService.hide();
    }
  }

  transformAmountRendaBrutaMensal(element: any) {
    let val = element.target.value;
    val = this._sharedService.transformAmount(val);
    element.target.value = val;
    this.form.patchValue({ rendaBrutaMensal: val });
  }
  
  transformAmountdespesaMensal(element: any) {
    let val = element.target.value;
    val = this._sharedService.transformAmount(val);
    element.target.value = val;
    this.form.patchValue({ despesaMensal: val });
  }

  transformPercent() {
    let elem = this.form.value.reservaEmergencia;
    let val = elem;
    val = val.replace(/\D/g, ''); // substitui qualquer caracter que não seja número por nada
    val = val.replace(/(\d)(\d{2})$/, '$1,$2'); // coloca virgula antes dos 2 últimos dígitos
    val = val.replace(/(?=(\d{3})+(\D))\B/g, ''); // remove ponto a cada 3 dígitos
    if (val.length > 0 && /\d$/.test(val)) {
      // verifica se o último caractere é um dígito
      val = `${val} %`; // adiciona o prefixo
    }
    this.form.patchValue({ reservaEmergencia: val });
  }
}
