import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CadastroService } from 'src/app/services/cadastro.service';
import { LoadingService } from 'src/app/services/loading.service';
import { localStorageVarNames } from 'src/environments/localStorageVarNames';

@Component({
  selector: 'app-dados-familiares',
  templateUrl: './dados-familiares.component.html',
  styleUrls: ['./dados-familiares.component.css'],
})
export class DadosFamiliaresComponent implements OnInit {
  formularioSeguroForm!: FormGroup;
  mostrarCamposConjuge: boolean = true;
  filhos: boolean = true;
  err: string | undefined;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    public loadingService: LoadingService,
    private _cadastroService: CadastroService
  ) {}

  ngOnInit(): void {
    this.formularioSeguroForm = this.fb.group({
      estadoCivil: ['Não Informado', Validators.required],
      dataCasamento: [null],
      ConjugeNome: [''],
      conjugeDataNasc: [null],
      possuiFilhos: ['Não Informado', Validators.required],
      etapa: 'Dados Familiares',
      id: 0,
    });
    
    
    this.formularioSeguroForm
      .get('estadoCivil')
      ?.valueChanges.subscribe((estadoCivil) => {
        this.mostrarCamposConjuge = estadoCivil !== 'Solteiro';
      });

    this.formularioSeguroForm
      .get('possuiFilhos')
      ?.valueChanges.subscribe((possuiFilhos) => {
        this.filhos = possuiFilhos !== 'Nao';
      });
  }

  onSubmit(): void {
    this.loadingService.show();

    if (this.formularioSeguroForm.valid) {
      this.formularioSeguroForm.get('possuiFilhos')?.setValue(this.filhos);
      var idcad = localStorage.getItem(localStorageVarNames.IdCadastroAtual);
      this.formularioSeguroForm.get('id')?.setValue(idcad);

      this._cadastroService.edit(this.formularioSeguroForm.value).subscribe(
        (res) => {
          if (res.sucesso) {
            setTimeout(() => {
              this.loadingService.hide();

              if (this.formularioSeguroForm.get('possuiFilhos')?.value) {
                this.router.navigate(['/cadastro/dados-descendentes']);
              } else {
                this.router.navigate(['/cadastro/dados-profissionais']);
              }

            }, 2000);
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
