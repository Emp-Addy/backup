import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-emp-list',
  templateUrl: './emp-list.component.html',
  styleUrls: ['./emp-list.component.css']
})
export class EmpListComponent implements OnInit {

  employees:Employee[]=[];
  constructor(private employeesService:EmployeesService) { }

  ngOnInit(): void {
    this.employeesService.getAllEmployees()
    .subscribe({
      next:(employees)=>{
        this.employees=employees;
      },
      error:(response)=>{
          console.log(response);
      }
    })
  }

}
