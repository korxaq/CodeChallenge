import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ButtonsModule } from 'ngx-bootstrap/buttons';

import { UserProjectsComponent } from './userProjects.component';
import { UserProjectsRoutingModule } from './userProjects-routing.module';

@NgModule({
  imports: [
    FormsModule,
    UserProjectsRoutingModule,
    BsDropdownModule,
    ButtonsModule.forRoot()
  ],
  declarations: [ UserProjectsComponent ]
})
export class DashboardModule { }
