import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-result',
  standalone: true,
  imports: [],
  templateUrl: './result.component.html',
  styleUrl: './result.component.css'
})
export class ResultComponent {

  @Input() data: any;
  @Output() resetForm = new EventEmitter<void>();

  submitAnotherTicket(): void {
    this.resetForm.emit();
  }
  
}
