import { Directive, ElementRef, HostListener, forwardRef } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';

@Directive({
  selector: '[appPhoneMask]',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => PhoneMaskDirective),
      multi: true
    }
  ]
})
export class PhoneMaskDirective implements ControlValueAccessor {
  private onTouched: () => void = () => {};
  private onChange: (value: string) => void = () => {};

  constructor(private el: ElementRef<HTMLInputElement>) {}

  @HostListener('input', ['$event.target.value'])
  onInput(value: string) {
    const clean = value.replace(/\D/g, '');
    const phonePattern = /^(\d{0,2})(\d{0,5})(\d{0,4})$/;
    const [, ddd, firstPart, secondPart] = clean.match(phonePattern) || [];

    let formatted = '';
    if (ddd) formatted += `(${ddd}`;
    if (firstPart) formatted += `) ${firstPart}`;
    if (secondPart) formatted += `-${secondPart}`;

    this.el.nativeElement.value = formatted;
    this.onChange(formatted);
  }

  @HostListener('blur')
  onBlur() {
    this.onTouched();
  }

  writeValue(value: string): void {
    this.el.nativeElement.value = value || '';
  }

  registerOnChange(fn: (value: string) => void): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: () => void): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.el.nativeElement.disabled = isDisabled;
  }
}

