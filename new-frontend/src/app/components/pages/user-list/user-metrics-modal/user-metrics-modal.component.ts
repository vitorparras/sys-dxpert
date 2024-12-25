import { Component, Inject, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { User } from '../../../../services/user.service';
import { Chart, ChartConfiguration } from 'chart.js/auto';

@Component({
  selector: 'app-user-metrics-modal',
  template: `
    <div class="metrics-modal">
      <!-- Header -->
      <div class="modal-header">
        <div class="user-profile">
          <div class="user-avatar">
            <img [src]="getAvatarUrl(data.user.name)" [alt]="data.user.name">
          </div>
          <div class="user-info">
            <h2>{{data.user.name}}</h2>
            <span class="user-role">Sales Representative</span>
          </div>
        </div>
        <button mat-icon-button mat-dialog-close class="close-button">
          <mat-icon>close</mat-icon>
        </button>
      </div>

      <!-- Quick Stats -->
      <div class="quick-stats">
        <div class="stat-card primary">
          <div class="stat-header">
            <span class="stat-label">Total Sales</span>
            <mat-icon>trending_up</mat-icon>
          </div>
          <div class="stat-value">R$ 125.430</div>
          <div class="stat-trend positive">
            <mat-icon>arrow_upward</mat-icon>
            15.3%
          </div>
        </div>

        <div class="stat-card info">
          <div class="stat-header">
            <span class="stat-label">Conversion Rate</span>
            <mat-icon>analytics</mat-icon>
          </div>
          <div class="stat-value">68%</div>
          <div class="stat-trend positive">
            <mat-icon>arrow_upward</mat-icon>
            8.7%
          </div>
        </div>

        <div class="stat-card warning">
          <div class="stat-header">
            <span class="stat-label">Active Clients</span>
            <mat-icon>groups</mat-icon>
          </div>
          <div class="stat-value">234</div>
          <div class="stat-trend negative">
            <mat-icon>arrow_downward</mat-icon>
            2.1%
          </div>
        </div>

        <div class="stat-card success">
          <div class="stat-header">
            <span class="stat-label">Satisfaction Score</span>
            <mat-icon>sentiment_very_satisfied</mat-icon>
          </div>
          <div class="stat-value">4.8<span class="value-suffix">/5</span></div>
          <div class="stat-trend positive">
            <mat-icon>arrow_upward</mat-icon>
            4.2%
          </div>
        </div>
      </div>

      <!-- Performance Chart -->
      <div class="performance-chart">
        <div class="chart-header">
          <h3>Performance Overview</h3>
          <div class="chart-actions">
            <button mat-button class="time-filter active">6 Months</button>
            <button mat-button class="time-filter">1 Year</button>
            <button mat-button class="time-filter">All Time</button>
          </div>
        </div>
        <div class="chart-container">
          <canvas #performanceChart></canvas>
        </div>
      </div>

      <!-- Additional Stats -->
      <div class="additional-stats">
        <div class="stat-row">
          <div class="stat-item">
            <mat-icon>schedule</mat-icon>
            <div class="stat-details">
              <span class="stat-title">Avg. Response Time</span>
              <span class="stat-number">2.5h</span>
            </div>
          </div>
          <div class="stat-item">
            <mat-icon>assignment_turned_in</mat-icon>
            <div class="stat-details">
              <span class="stat-title">Tasks Completed</span>
              <span class="stat-number">94%</span>
            </div>
          </div>
          <div class="stat-item">
            <mat-icon>military_tech</mat-icon>
            <div class="stat-details">
              <span class="stat-title">Performance Rank</span>
              <span class="stat-number">#3</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  `,
  styles: [`
    .metrics-modal {
      background: white;
      border-radius: 24px;
      padding: 32px;
      max-width: 900px;
      position: relative;
      overflow: hidden;
    }

    /* Header Styles */
    .modal-header {
      display: flex;
      justify-content: space-between;
      align-items: center;
      margin-bottom: 32px;
    }

    .user-profile {
      display: flex;
      align-items: center;
      gap: 16px;
    }

    .user-avatar {
      width: 56px;
      height: 56px;
      border-radius: 16px;
      overflow: hidden;
      box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);

      img {
        width: 100%;
        height: 100%;
        object-fit: cover;
      }
    }

    .user-info {
      h2 {
        margin: 0;
        font-size: 24px;
        font-weight: 600;
        color: #1a1f35;
      }

      .user-role {
        color: #64748b;
        font-size: 14px;
      }
    }

    .close-button {
      position: absolute;
      top: 24px;
      right: 24px;
      color: #64748b;
      transition: all 0.3s ease;

      &:hover {
        background: rgba(0, 0, 0, 0.05);
        color: #1a1f35;
      }
    }

    /* Quick Stats */
    .quick-stats {
      display: grid;
      grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
      gap: 20px;
      margin-bottom: 32px;
    }

    .stat-card {
      background: white;
      border-radius: 16px;
      padding: 20px;
      box-shadow: 0 4px 20px rgba(0, 0, 0, 0.08);
      transition: transform 0.3s ease, box-shadow 0.3s ease;

      &:hover {
        transform: translateY(-4px);
        box-shadow: 0 8px 25px rgba(0, 0, 0, 0.12);
      }

      &.primary { border-left: 4px solid #FF6B00; }
      &.info { border-left: 4px solid #0ea5e9; }
      &.warning { border-left: 4px solid #f59e0b; }
      &.success { border-left: 4px solid #10b981; }

      .stat-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-bottom: 12px;

        .stat-label {
          font-size: 14px;
          color: #64748b;
          font-weight: 500;
        }

        mat-icon {
          font-size: 20px;
          width: 20px;
          height: 20px;
        }
      }

      &.primary mat-icon { color: #FF6B00; }
      &.info mat-icon { color: #0ea5e9; }
      &.warning mat-icon { color: #f59e0b; }
      &.success mat-icon { color: #10b981; }

      .stat-value {
        font-size: 28px;
        font-weight: 600;
        color: #1a1f35;
        margin-bottom: 8px;

        .value-suffix {
          font-size: 16px;
          color: #64748b;
          margin-left: 2px;
        }
      }

      .stat-trend {
        display: flex;
        align-items: center;
        gap: 4px;
        font-size: 14px;
        font-weight: 500;

        mat-icon {
          font-size: 16px;
          width: 16px;
          height: 16px;
        }

        &.positive {
          color: #10b981;
        }

        &.negative {
          color: #ef4444;
        }
      }
    }

    /* Performance Chart */
    .performance-chart {
      background: white;
      border-radius: 20px;
      padding: 24px;
      margin-bottom: 32px;
      box-shadow: 0 4px 20px rgba(0, 0, 0, 0.08);

      .chart-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-bottom: 24px;

        h3 {
          margin: 0;
          font-size: 18px;
          font-weight: 600;
          color: #1a1f35;
        }

        .chart-actions {
          display: flex;
          gap: 8px;

          .time-filter {
            font-size: 13px;
            color: #64748b;
            padding: 6px 12px;
            border-radius: 20px;
            transition: all 0.3s ease;

            &:hover {
              background: rgba(0, 0, 0, 0.05);
            }

            &.active {
              background: #FF6B00;
              color: white;
            }
          }
        }
      }

      .chart-container {
        height: 300px;
        position: relative;
      }
    }

    /* Additional Stats */
    .additional-stats {
      .stat-row {
        display: grid;
        grid-template-columns: repeat(auto-fit, minmax(180px, 1fr));
        gap: 20px;
      }

      .stat-item {
        display: flex;
        align-items: center;
        gap: 12px;
        padding: 16px;
        background: white;
        border-radius: 12px;
        box-shadow: 0 4px 20px rgba(0, 0, 0, 0.08);
        transition: transform 0.3s ease;

        &:hover {
          transform: translateY(-2px);
        }

        mat-icon {
          color: #FF6B00;
          font-size: 24px;
          width: 24px;
          height: 24px;
        }

        .stat-details {
          display: flex;
          flex-direction: column;

          .stat-title {
            font-size: 13px;
            color: #64748b;
          }

          .stat-number {
            font-size: 18px;
            font-weight: 600;
            color: #1a1f35;
          }
        }
      }
    }

    @media (max-width: 768px) {
      .metrics-modal {
        padding: 20px;
      }

      .quick-stats {
        grid-template-columns: 1fr;
      }

      .chart-header {
        flex-direction: column;
        gap: 16px;
        align-items: flex-start;
      }

      .additional-stats .stat-row {
        grid-template-columns: 1fr;
      }
    }
  `]
})
export class UserMetricsModalComponent implements AfterViewInit {
  @ViewChild('performanceChart') performanceChart!: ElementRef;

  constructor(@Inject(MAT_DIALOG_DATA) public data: { user: User }) {}

  getAvatarUrl(name: string): string {
    return `https://ui-avatars.com/api/?name=${encodeURIComponent(name)}&background=FF6B00&color=fff`;
  }

  ngAfterViewInit() {
    const ctx = this.performanceChart.nativeElement.getContext('2d');
    
    const chartConfig: ChartConfiguration = {
      type: 'line',
      data: {
        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],
        datasets: [{
          label: 'Performance',
          data: [65, 78, 72, 85, 82, 90],
          borderColor: '#FF6B00',
          backgroundColor: 'rgba(255, 107, 0, 0.1)',
          borderWidth: 2,
          tension: 0.4,
          fill: true,
          pointBackgroundColor: '#FF6B00',
          pointBorderColor: 'white',
          pointBorderWidth: 2,
          pointHoverBackgroundColor: '#FF6B00',
          pointHoverBorderColor: 'white',
          pointHoverBorderWidth: 2,
          pointRadius: 5,
          pointHoverRadius: 7
        }]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            display: false
          },
          tooltip: {
            mode: 'index',
            intersect: false,
            backgroundColor: 'rgba(26, 31, 53, 0.9)',
            titleColor: '#fff',
            bodyColor: '#fff',
            borderColor: 'rgba(255, 255, 255, 0.2)',
            borderWidth: 1,
            padding: 10,
            bodyFont: {
              size: 14
            },
            titleFont: {
              size: 16,
              weight: 'bold'
            }
          }
        },
        interaction: {
          intersect: false,
          mode: 'index'
        },
        scales: {
          y: {
            beginAtZero: true,
            border: {
              display: false
            },
            grid: {
              color: 'rgba(0, 0, 0, 0.05)',
              drawTicks: false
            },
            ticks: {
              color: '#64748b',
              padding: 10,
              font: {
                size: 11
              }
            }
          },
          x: {
            border: {
              display: false
            },
            grid: {
              display: false
            },
            ticks: {
              color: '#64748b',
              padding: 10,
              font: {
                size: 11
              }
            }
          }
        }
      }
    };

    new Chart(ctx, chartConfig);
  }
}

