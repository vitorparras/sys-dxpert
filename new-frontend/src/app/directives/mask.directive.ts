import { Directive, ElementRef, HostListener, Input } from '@angular/core';
import { NgControl } from '@angular/forms';

@Directive({
  selector: '[appMask]'
})
export class MaskDirective {
  @Input('appMask') mask: string = '';

  constructor(private el: ElementRef<HTMLInputElement>, private control: NgControl) {}

  @HostListener('input', ['$event'])
  onInput(event: Event): void {
    const input = event.target as HTMLInputElement;
    const trimmed = this.trimValue(input.value);
    const formatted = this.format(trimmed);

    input.value = formatted;
    this.control.control?.setValue(formatted, { emitEvent: false });
  }

  private trimValue(value: string): string {
    return value.replace(/\D/g, '');
  }

  private format(value: string): string {
    let result = '';
    let index = 0;

    for (let i = 0; i < this.mask.length && index < value.length; i++) {
      if (this.mask[i] === '0') {
        result += value[index++];
      } else {
        result += this.mask[i];
      }
    }

    return result;
  }
}

