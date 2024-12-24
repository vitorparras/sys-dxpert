import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CadastroService } from 'src/app/services/cadastro.service';
import { LoadingService } from 'src/app/services/loading.service';
import { localStorageVarNames } from 'src/environments/localStorageVarNames';

@Component({
  selector: 'app-dados-profissionais',
  templateUrl: './dados-profissionais.component.html',
  styleUrls: ['./dados-profissionais.component.css'],
})
export class DadosProfissionaisComponent {
  @Input() id: string | undefined;
  err: string | undefined;
  form: FormGroup;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    public loadingService: LoadingService,
    private _cadastroService: CadastroService
  ) {
    this.form = this.fb.group({
      profissao: ['', Validators.required],
      ocupacao: ['', Validators.required],
      anosContribuicao: ['', Validators.required],
      dataPosse: [''],
      regimeContratacao: ['', Validators.required],
      etapa: 'Dados Profissionais',
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
              this.router.navigate(['/cadastro/dados-financeiros']);
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
}
