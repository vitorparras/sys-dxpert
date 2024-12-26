import { Directive, ElementRef, HostListener, forwardRef } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';

@Directive({
  selector: '[appDateMask]',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DateMaskDirective),
      multi: true
    }
  ]
})
export class DateMaskDirective implements ControlValueAccessor {
  private onTouched: () => void = () => {};
  private onChange: (value: string) => void = () => {};

  constructor(private el: ElementRef<HTMLInputElement>) {}

  @HostListener('input', ['$event.target.value'])
  onInput(value: string) {
    const clean = value.replace(/\D/g, '');
    const datePattern = /^(\d{0,2})(\d{0,2})(\d{0,4})$/;
    const [, day, month, year] = clean.match(datePattern) || [];

    let formatted = '';
    if (day) formatted += day;
    if (month) formatted += `/${month}`;
    if (year) formatted += `/${year}`;

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

