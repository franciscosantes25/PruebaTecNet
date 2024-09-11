import {ChangeDetectionStrategy, Component, OnInit, signal} from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {provideNativeDateAdapter} from '@angular/material/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatDividerModule} from '@angular/material/divider';
import { Employee } from '../../models/employee';
import { ApiService } from '../../core/api.service';
import { Observable } from 'rxjs';
import { State } from '../../models/state';
import { CommonModule } from '@angular/common';
import { Position } from '../../models/position';

@Component({
  selector: 'app-employee',
  standalone: true,
  providers: [provideNativeDateAdapter()],
  imports: [CommonModule
    , MatFormFieldModule
    , MatInputModule
    , MatIconModule
    , MatSelectModule
    , MatDatepickerModule
    , FormsModule
    , ReactiveFormsModule
    , MatCardModule
    , MatButtonModule
    , MatDividerModule
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent implements OnInit {

  employeeForm!: FormGroup;
  errorMessage = signal('');
  states$! : Observable<State[]>
  positions$! : Observable<Position[]>
  readonly email = new FormControl('', [Validators.required, Validators.email]);
  
  constructor(private fb: FormBuilder
    , private _service : ApiService
  ) {}

  ngOnInit() {
    this.employeeForm = this.fb.group({
      photograph: ['']
      , name:  ['',  Validators.required]
      , lastName:  ['' , Validators.required]
      , positionId	:  ['1' , Validators.required]
      , birthDate	:  ['']
      , hiringDate	:  ['']
      , address	:  ['']
      , phone	:  ['', [Validators.pattern("^[0-9]*$")]]
      , email	:  ['', [Validators.required, Validators.email]]
      , stateId	:  ['', Validators.required]
    });

    this.loadCatalogs()
  }

  loadCatalogs(){
    this.states$ = this._service.getStateAll()
    this.positions$ = this._service.getPositionAll()
  }

  onSubmit() {
    if(this.employeeForm.valid){
      let employee : Employee = {
        id : 0
        , name : this.employeeForm.controls['name'].value
        , photograph : '' 
        , lastName : this.employeeForm.controls['lastName'].value
        , positionId : this.employeeForm.controls['positionId'].value
        , birthDate : this.employeeForm.controls['birthDate'].value
        , hiringDate : this.employeeForm.controls['hiringDate'].value
        , address : this.employeeForm.controls['address'].value
        , phone : this.employeeForm.controls['phone'].value
        , email : this.employeeForm.controls['email'].value
        , stateId : this.employeeForm.controls['stateId'].value
        , isVisible : true 
        , isBySystem : true 
        , insertDate : new Date()
        , insertUserId : 1 // user logged
        , updateDate : new Date()
        , updateUserId : 1 
      }

      this._service.saveEmployee(employee)
    }else{
      //mensaje de error
    }  
  }

  updateErrorMessage() {
    if (this.employeeForm.controls['email'].hasError('required')) {
      this.errorMessage.set('Email requerido');
    } else if (this.employeeForm.controls['email'].hasError('email')) {
      this.errorMessage.set('Email no valido');
    } else {
      this.errorMessage.set('');
    }
  }

}
