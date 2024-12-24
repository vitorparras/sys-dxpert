import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Sexo } from 'src/app/domain/enums/sexo';
import { CadastroService } from 'src/app/services/cadastro.service';
import { LoadingService } from 'src/app/services/loading.service';
import { localStorageVarNames } from 'src/environments/localStorageVarNames';

@Component({
  selector: 'app-dados-pessoais',
  templateUrl: './dados-pessoais.component.html',
  styleUrls: ['./dados-pessoais.component.css'],
})
export class DadosPessoaisComponent {
  selecao: Sexo | undefined;
  err: string | undefined;
  form!: FormGroup;
  @Input() id: string | undefined;

  constructor(
    private fb: FormBuilder,
    public loadingService: LoadingService,
    private router: Router,
    private _cadastroService: CadastroService
  ) {}

  ngOnInit() {

    var id = localStorage.getItem(localStorageVarNames.IdUser);

    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      celular: ['', Validators.required],
      nome: ['', Validators.required],
      dataNascimento: ['', Validators.required],
      sexo: ['', Validators.required],
      etapa: 'Dados Pessoais',
      IdUsuarioResponsavel: id,
    });

    this.form.get('sexo')?.valueChanges.subscribe((val) => {
      this.selecao = val;
    });
  }

  enviar() {
    this.loadingService.show();

    if (this.form.valid) {
      this._cadastroService.edit(this.form.value).subscribe(
        (res) => {
          if (res.sucesso) {
            var idcadastro = res.cadastro.id;
            localStorage.setItem(
              localStorageVarNames.IdCadastroAtual,
              idcadastro
            );

            setTimeout(() => {
              this.loadingService.hide();
              this.router.navigate(['/cadastro/dados-familiares']);
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
}
