import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CadastroService } from 'src/app/services/cadastro.service';
import { LoadingService } from 'src/app/services/loading.service';
import { localStorageVarNames } from 'src/environments/localStorageVarNames';

@Component({
  selector: 'app-dados-descendentes',
  templateUrl: './dados-descendentes.component.html',
  styleUrls: ['./dados-descendentes.component.css'],
})
export class DadosDescendentesComponent {
  constructor(
    private fb: FormBuilder,
    public loadingService: LoadingService,
    private router: Router,
    private _cadastroService: CadastroService
  ) {}

  filhos: any[] = [{ nome: '', dtNasc: '' }];
  form!: FormGroup;
  err: string | undefined;

  ngOnInit() {
    this.form = this.fb.group({
      quantidadeFilhos: ['', Validators.required],
      filhosMaiores: ['', Validators.required],
      etapa: 'Dados Descendentes - Filhos',
      id: 0,
    });
  }

  onInput(event: any): void {
    if (!event.target.value) {
      event.target.type = 'text';
    }
  }
  adicionarFilho() {
    this.filhos.push({ nome: '', dtNasc: '' });
  }

  enviarFormulario() {
    this.loadingService.show();
    var idCad = localStorage.getItem(localStorageVarNames.IdCadastroAtual);
    this.form.get('id')?.setValue(idCad);

    if (this.form.valid) {
      this._cadastroService.edit(this.form.value).subscribe(
        (res) => {
          if (res.sucesso) {
            this._cadastroService
              .addDescendentes({ idCad: idCad, filhos: this.filhos })
              .subscribe((res) => {
                if (res.sucesso) {
                  setTimeout(() => {
                    this.loadingService.hide();
                    this.router.navigate(['/cadastro/dados-profissionais']);
                  }, 2000);
                } else {
                  this.err = res.Message;
                  this.loadingService.hide();
                }
              });
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

  onFocus(event: any): void {
    event.target.type = 'date';
  }
}
