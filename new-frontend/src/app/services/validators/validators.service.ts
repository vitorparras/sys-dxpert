import { Injectable } from '@angular/core';
import { AbstractControl, ValidatorFn } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ValidatorsService {
  dateBrPattern(): ValidatorFn {
    return (control: AbstractControl): {[key: string]: any} | null => {
      const valid = /^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/\d{4}$/.test(control.value);
      return valid ? null : { 'dateBrPattern': {value: control.value} };
    };
  }

  phonePattern(): ValidatorFn {
    return (control: AbstractControl): {[key: string]: any} | null => {
      const valid = /^$$\d{2}$$\s\d{5}-\d{4}$/.test(control.value);
      return valid ? null : { 'phonePattern': {value: control.value} };
    };
  }

  dateIsValid(): ValidatorFn {
    return (control: AbstractControl): {[key: string]: any} | null => {
      if (!control.value) return null;
      const [day, month, year] = control.value.split('/').map(Number);
      const date = new Date(year, month - 1, day);
      const valid = date && date.getFullYear() === year && date.getMonth() === month - 1 && date.getDate() === day;
      return valid ? null : { 'dateIsValid': {value: control.value} };
    };
  }
}

