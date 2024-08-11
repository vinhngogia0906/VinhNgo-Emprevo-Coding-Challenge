import {ChangeDetectionStrategy, Component, OnInit, EventEmitter, Output, ChangeDetectorRef} from '@angular/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import {provideNativeDateAdapter} from '@angular/material/core';
import {FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import { CommonModule } from '@angular/common';

const SUBMIT_DATES = gql`
  mutation SubmitTicket($entry: DateTime!, $exit: DateTime!) {
    submitTicket(ticket: {entry: $entry, exit: $exit}) {
      entry
      exit
      totalPrice
      id
    }
  }
`;

interface TimeOption {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-submit',
  standalone: true,
  providers: [provideNativeDateAdapter()],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
],
  templateUrl: './submit.component.html',
  styleUrl: './submit.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SubmitComponent implements OnInit {

  @Output() formSubmitted: EventEmitter<any> = new EventEmitter();
  dateForm!: FormGroup;
  hours: TimeOption[] = [];
  minutes: TimeOption[] = [];
  errorMessage = "";

  constructor(private fb: FormBuilder, private apollo: Apollo, private cdr: ChangeDetectorRef) {
    this.populateTimeOptions();
  }

  populateTimeOptions() {
    for (let i = 0; i < 24; i++) {
      const hourString = i < 10 ? '0' + i : i.toString();
      this.hours.push({ value: hourString, viewValue: hourString });
    }

    for (let i = 0; i < 60; i++) {
      const minuteString = i < 10 ? '0' + i : i.toString();
      this.minutes.push({ value: minuteString, viewValue: minuteString });
    }
  }


  ngOnInit(): void {
    this.dateForm = this.fb.group({
      entryDate: ['', Validators.required],
      entryHour: ['', Validators.required],
      entryMinute: ['', Validators.required],
      exitDate: ['', Validators.required],
      exitHour: ['', Validators.required],
      exitMinute: ['', Validators.required],
    });
    this.errorMessage = "";
  }

  onSubmit(): void {
    const formValues = this.dateForm.value;

    // Combine date, hour, and minute for entry DateTime
    const entryDate = formValues.entryDate;
    const entryHour = formValues.entryHour;
    const entryMinute = formValues.entryMinute;
    const entryDateTime = new Date(entryDate);
    entryDateTime.setHours(entryHour, entryMinute);

    // Combine date, hour, and minute for exit DateTime
    const exitDate = formValues.exitDate;
    const exitHour = formValues.exitHour;
    const exitMinute = formValues.exitMinute;
    const exitDateTime = new Date(exitDate);
    exitDateTime.setHours(exitHour, exitMinute);
    

    this.apollo.mutate({
      mutation: SUBMIT_DATES,
      variables: {
        entry: entryDateTime,
        exit: exitDateTime
      }
    }).subscribe(({ data }) => {
      this.formSubmitted.emit(data);
    }, (error) => {
      console.log('Error:', error);
      this .errorMessage = "Submission failed. Please check your input again, exit date must not exceed today's day and entry time must be before exit time."
      this.cdr.detectChanges();
    });
  }
}
