import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmpListComponent } from './components/employees/emp-list/emp-list.component';
import { AddEmployeeComponent } from './components/employees/add-employee/add-employee.component';
import { FormsModule } from '@angular/forms';
import { EditEmployeeComponent } from './components/employees/edit-employee/edit-employee.component';

@NgModule({
  declarations: [
    AppComponent,
    EmpListComponent,
    AddEmployeeComponent,
    EditEmployeeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
