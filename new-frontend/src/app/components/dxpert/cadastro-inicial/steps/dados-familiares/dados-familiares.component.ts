import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dados-familiares',
  templateUrl: './dados-familiares.component.html',
  styleUrls: ['./dados-familiares.component.css'],
})
export class DadosFamiliaresComponent implements OnInit {
  formularioSeguroForm!: FormGroup;
  mostrarCamposConjuge: boolean = false;
  filhos: boolean = false;
  err: string | undefined;

  constructor(
    private fb: FormBuilder,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.initForm();
    this.setupFormListeners();
  }

  private initForm(): void {
    this.formularioSeguroForm = this.fb.group({
      estadoCivil: ['', Validators.required],
      dataCasamento: [''],
      ConjugeNome: [''],
      conjugeDataNasc: [''],
      possuiFilhos: ['', Validators.required],
      etapa: 'Dados Familiares',
      id: 0,
    });
  }

  private setupFormListeners(): void {
    this.formularioSeguroForm.get('estadoCivil')?.valueChanges.subscribe((estadoCivil) => {
      this.mostrarCamposConjuge = estadoCivil === 'Casado';
      this.updateValidators();
    });

    this.formularioSeguroForm.get('possuiFilhos')?.valueChanges.subscribe((possuiFilhos) => {
      this.filhos = possuiFilhos === 'Sim';
    });
  }

  private updateValidators(): void {
    const dataCasamentoControl = this.formularioSeguroForm.get('dataCasamento');
    const conjugeNomeControl = this.formularioSeguroForm.get('ConjugeNome');
    const conjugeDataNascControl = this.formularioSeguroForm.get('conjugeDataNasc');

    if (this.mostrarCamposConjuge) {
      dataCasamentoControl?.setValidators([Validators.required, Validators.pattern(/^\d{2}\/\d{2}\/\d{4}$/)]);
      conjugeNomeControl?.setValidators([Validators.required]);
      conjugeDataNascControl?.setValidators([Validators.required, Validators.pattern(/^\d{2}\/\d{2}\/\d{4}$/)]);
    } else {
      dataCasamentoControl?.clearValidators();
      conjugeNomeControl?.clearValidators();
      conjugeDataNascControl?.clearValidators();
    }

    dataCasamentoControl?.updateValueAndValidity();
    conjugeNomeControl?.updateValueAndValidity();
    conjugeDataNascControl?.updateValueAndValidity();
  }

  onSubmit(): void {
    if (this.formularioSeguroForm.valid) {
      console.log('Enviando dados...', this.formularioSeguroForm.value);
      this.router.navigate(['relatorio/cadastro/dados-descendentes']);
    } else {
      this.err = 'Por favor, preencha todos os campos obrigatórios corretamente.';
      this.markFormGroupTouched(this.formularioSeguroForm);
    }
  }

  private markFormGroupTouched(formGroup: FormGroup) {
    Object.values(formGroup.controls).forEach(control => {
      control.markAsTouched();
      if (control instanceof FormGroup) {
        this.markFormGroupTouched(control);
      }
    });
  }
}

