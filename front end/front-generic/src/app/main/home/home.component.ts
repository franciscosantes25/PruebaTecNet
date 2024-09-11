import { Component } from '@angular/core';
import { EmployeeComponent } from "../../shared/employee/employee.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [EmployeeComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
