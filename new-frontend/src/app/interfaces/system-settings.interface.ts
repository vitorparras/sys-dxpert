export type SettingType = 'text' | 'number' | 'boolean' | 'select';
export type SettingCategory = 'general' | 'email' | 'security' | 'integration';

export interface SystemSetting {
  id: number;
  key: string;
  value: string;
  type: SettingType;
  category: SettingCategory;
  label: string;
  description: string;
  required: boolean;
  options?: string[]; // For select type
  validation?: {
    min?: number;
    max?: number;
    pattern?: string;
  };
}

