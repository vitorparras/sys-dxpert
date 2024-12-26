import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dados-financeiros',
  templateUrl: './dados-financeiros.component.html',
  styleUrls: ['./dados-financeiros.component.css'],
})
export class DadosFinanceirosComponent implements OnInit {
  form!: FormGroup;
  err: string = '';

  constructor(
    private fb: FormBuilder,
    private router: Router,
  ) {}

  ngOnInit() {
    this.initForm();
  }

  private initForm() {
    this.form = this.fb.group({
      impostoDeRenda: ['', Validators.required],
      rendaBruta: ['', Validators.required],
      despesaMensal: ['', Validators.required],
      reservaEmergencia: ['', Validators.required],
      tempoReserva: ['', [Validators.required, Validators.min(1)]],
      etapa: 'Dados Financeiros',
      id: [0, Validators.required],
    });
  }

  enviar() {
    if (this.form.valid) {
      console.log('Formulário válido:', this.form.value);
      this.router.navigate(['relatorio/cadastro/dados-saude']);
    } else {
      this.err = 'Por favor, preencha todos os campos obrigatórios corretamente.';
      this.markFormGroupTouched(this.form);
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

  transformAmountRendaBrutaMensal(element: any) {
    let val = element.target.value;
    val = this.formatCurrency(val);
    element.target.value = val;
    this.form.patchValue({ rendaBruta: val });
  }
  
  transformAmountdespesaMensal(element: any) {
    let val = element.target.value;
    val = this.formatCurrency(val);
    element.target.value = val;
    this.form.patchValue({ despesaMensal: val });
  }

  transformPercent() {
    let elem = this.form.value.reservaEmergencia;
    let val = elem;
    val = val.replace(/\D/g, '');
    val = val.replace(/^0+/, '');
    if (val.length > 2) {
      val = val.slice(0, -2) + ',' + val.slice(-2);
    }
    val = val.replace(/(?=(\d{3})+(\D))\B/g, '.');
    if (val.length > 0) {
      val = `${val} %`;
    }
    this.form.patchValue({ reservaEmergencia: val });
  }

  transformTempoReserva(element: any) {
    let val = element.target.value;
    val = val.replace(/\D/g, '');
    val = val.replace(/^0+/, '');
    if (val) {
      val = `${val} meses`;
    }
    element.target.value = val;
    this.form.patchValue({ tempoReserva: val });
  }

  private formatCurrency(value: string): string {
    value = value.replace(/\D/g, '');
    value = value.replace(/(\d)(\d{2})$/, '$1,$2');
    value = value.replace(/(?=(\d{3})+(\D))\B/g, '.');
    return `R$ ${value}`;
  }
}

