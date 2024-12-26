import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appInputMask]'
})
export class InputMaskDirective {
  @Input('appInputMask') maskPattern!: string;

  constructor(private el: ElementRef) {}

  @HostListener('input', ['$event'])
  onInput(event: Event): void {
    const input = event.target as HTMLInputElement;
    let value = input.value.replace(/\D/g, '');
    let maskedValue = '';
    let maskIndex = 0;

    for (let i = 0; i < value.length && maskIndex < this.maskPattern.length; i++) {
      if (this.maskPattern[maskIndex] === '0') {
        maskedValue += value[i];
        maskIndex++;
      } else {
        maskedValue += this.maskPattern[maskIndex];
        maskIndex++;
        i--;
      }
    }

    input.value = maskedValue;
  }
}

