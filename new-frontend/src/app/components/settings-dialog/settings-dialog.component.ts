import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SystemSetting, SettingType, SettingCategory } from '../../interfaces/system-settings.interface';

@Component({
  selector: 'app-settings-dialog',
  templateUrl: './settings-dialog.component.html',
  styleUrls: ['./settings-dialog.component.scss']
})
export class SettingsDialogComponent {
  settingForm: FormGroup;
  types: SettingType[] = ['text', 'number', 'boolean', 'select'];
  categories: SettingCategory[] = ['general', 'email', 'security', 'integration'];
  isEditMode: boolean;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<SettingsDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Partial<SystemSetting>
  ) {
    this.isEditMode = !!data.id;
    this.settingForm = this.fb.group({
      key: [this.data.key || '', [
        Validators.required,
        Validators.pattern('^[a-z0-9_]+$')
      ]],
      label: [this.data.label || '', [
        Validators.required,
        Validators.minLength(3)
      ]],
      value: [this.data.value || '', [
        Validators.required
      ]],
      type: [this.data.type || 'text', [
        Validators.required
      ]],
      category: [this.data.category || 'general', [
        Validators.required
      ]],
      description: [this.data.description || '', [
        Validators.required,
        Validators.minLength(10)
      ]],
      required: [this.data.required !== undefined ? this.data.required : true],
      options: [this.data.options || []],
      validation: this.fb.group({
        min: [this.data.validation?.min || null],
        max: [this.data.validation?.max || null],
        pattern: [this.data.validation?.pattern || null]
      })
    });
    this.initForm();
  }

  private initForm() {
    // Watch for type changes to update validation
    this.settingForm.get('type')?.valueChanges.subscribe(type => {
      this.updateValidationBasedOnType(type);
    });
  }

  private updateValidationBasedOnType(type: SettingType) {
    const valueControl = this.settingForm.get('value');
    const validationGroup = this.settingForm.get('validation');
    const optionsControl = this.settingForm.get('options');

    if (valueControl && validationGroup && optionsControl) {
      // Reset validations
      valueControl.clearValidators();
      valueControl.addValidators(Validators.required);

      switch (type) {
        case 'number':
          valueControl.addValidators(Validators.pattern('^[0-9]*$'));
          break;
        case 'boolean':
          valueControl.setValue(valueControl.value === 'true');
          break;
        case 'select':
          if (!optionsControl.value || !optionsControl.value.length) {
            optionsControl.setValue(['']);
          }
          break;
      }

      valueControl.updateValueAndValidity();
    }
  }

  onSubmit() {
    if (this.settingForm.valid) {
      const formValue = this.settingForm.value;
      
      // Clean up validation object
      if (!formValue.validation.min && !formValue.validation.max && !formValue.validation.pattern) {
        delete formValue.validation;
      }

      // Clean up options if not select type
      if (formValue.type !== 'select') {
        delete formValue.options;
      }

      // Ensure boolean values are strings
      if (formValue.type === 'boolean') {
        formValue.value = formValue.value.toString();
      }

      this.dialogRef.close({
        ...formValue,
        id: this.data.id
      });
    }
  }

  addOption() {
    const options = this.settingForm.get('options')?.value || [];
    options.push('');
    this.settingForm.patchValue({ options });
  }

  removeOption(index: number) {
    const options = this.settingForm.get('options')?.value || [];
    options.splice(index, 1);
    this.settingForm.patchValue({ options });
  }

  updateOption(index: number, event: Event) {
    const options = this.settingForm.get('options')?.value;
    options[index] = (event.target as HTMLInputElement).value;
    this.settingForm.patchValue({ options });
  }

  getTypeIcon(type: SettingType): string {
    const icons: Record<SettingType, string> = {
      text: 'text_fields',
      number: 'numbers',
      boolean: 'toggle_on',
      select: 'list'
    };
    return icons[type];
  }

  getCategoryIcon(category: SettingCategory): string {
    const icons: Record<SettingCategory, string> = {
      general: 'settings',
      email: 'email',
      security: 'security',
      integration: 'integration_instructions'
    };
    return icons[category];
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}

