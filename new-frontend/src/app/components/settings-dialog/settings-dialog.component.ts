import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SystemSetting } from '../../services/system-settings.service';

@Component({
  selector: 'app-settings-dialog',
  templateUrl: './settings-dialog.component.html',
  styleUrls: ['./settings-dialog.component.scss']
})
export class SettingsDialogComponent {
  settingForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<SettingsDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: SystemSetting
  ) {
    this.settingForm = this.fb.group({
      key: [data.key || '', Validators.required],
      value: [data.value || '', Validators.required],
      description: [data.description || '', Validators.required]
    });
  }

  onSubmit() {
    if (this.settingForm.valid) {
      this.dialogRef.close({
        ...this.data,
        ...this.data,
        ...this.settingForm.value
      });
    }
  }

  onCancel() {
    this.dialogRef.close();
  }
}

