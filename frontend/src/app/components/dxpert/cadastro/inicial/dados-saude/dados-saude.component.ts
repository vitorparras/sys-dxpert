import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CadastroService } from 'src/app/services/cadastro.service';
import { LoadingService } from 'src/app/services/loading.service';
import { localStorageVarNames } from 'src/environments/localStorageVarNames';

@Component({
  selector: 'app-dados-saude',
  templateUrl: './dados-saude.component.html',
  styleUrls: ['./dados-saude.component.css']
})
export class DadosSaudeComponent {

  form!: FormGroup;
  @Input() id: string | undefined;
  baseUrl: string = '';
  err: string | undefined;
  
  constructor(private fb: FormBuilder,
     private router: Router,
    public loadingService: LoadingService,
    private _cadastroService: CadastroService
    ) {
    this.form = this.fb.group({
      problemaSaude: ['', Validators.required],
      tomaRemedio: ['', Validators.required],
      fuma: ['', Validators.required],
      maiorPrioridade: ['', Validators.required],
      etapa: 'Dados Saude',
      id: 0,
    });
    this.baseUrl = window.location.origin;
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
              this.router.navigate(['/relatorio/gerando']);
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
