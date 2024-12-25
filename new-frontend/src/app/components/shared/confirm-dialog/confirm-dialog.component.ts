import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

interface ConfirmDialogData {
  title: string;
  message: string;
  confirmText: string;
  cancelText: string;
}

@Component({
  selector: 'app-confirm-dialog',
  template: `
    <div class="confirm-dialog">
      <div class="dialog-icon">
        <mat-icon>warning</mat-icon>
      </div>
      <h2 mat-dialog-title>{{ data.title }}</h2>
      <div mat-dialog-content>
        <p>{{ data.message }}</p>
      </div>
      <div mat-dialog-actions>
        <button 
          mat-button 
          [mat-dialog-close]="false"
          class="cancel-button">
          {{ data.cancelText }}
        </button>
        <button 
          mat-flat-button
          [mat-dialog-close]="true"
          class="confirm-button">
          {{ data.confirmText }}
        </button>
      </div>
    </div>
  `,
  styles: [`
    .confirm-dialog {
      padding: 24px;
      text-align: center;
    }

    .dialog-icon {
      width: 64px;
      height: 64px;
      margin: 0 auto 24px;
      background: linear-gradient(135deg, rgba(244, 67, 54, 0.1), rgba(244, 67, 54, 0.2));
      border-radius: 50%;
      display: flex;
      align-items: center;
      justify-content: center;

      mat-icon {
        font-size: 32px;
        width: 32px;
        height: 32px;
        color: #f44336;
      }
    }

    h2 {
      margin: 0 0 16px;
      font-size: 24px;
      font-weight: 500;
      color: rgba(0, 0, 0, 0.87);
    }

    p {
      margin: 0 0 24px;
      color: rgba(0, 0, 0, 0.6);
      font-size: 16px;
      line-height: 1.5;
    }

    [mat-dialog-actions] {
      padding: 0;
      margin: 0;
      display: flex;
      gap: 12px;
      justify-content: center;
    }

    .cancel-button {
      color: rgba(0, 0, 0, 0.6);
      
      &:hover {
        background: rgba(0, 0, 0, 0.04);
      }
    }

    .confirm-button {
      background: linear-gradient(135deg, #f44336, #d32f2f);
      color: white;
      padding: 0 24px;
      
      &:hover {
        box-shadow: 0 4px 12px rgba(244, 67, 54, 0.3);
      }
    }

    button {
      min-width: 120px;
      border-radius: 8px;
      font-weight: 500;
      height: 40px;
      transition: all 0.3s ease;
    }
  `]
})
export class ConfirmDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<ConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ConfirmDialogData
  ) {}
}

