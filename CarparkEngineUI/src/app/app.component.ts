import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SubmitComponent } from './submit/submit.component';
import { ResultComponent } from './result/result.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    CommonModule,
    SubmitComponent,
    ResultComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Emprevo Carpark UI';

  isFormSubmitted = false;
  resultData: any;

  onFormSubmitted(data: any): void {
    this.isFormSubmitted = true;
    this.resultData = data;
  }

  onResetForm(): void {
    this.isFormSubmitted = false;
  }
  
}
