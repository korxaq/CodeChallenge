import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ButtonsModule } from 'ngx-bootstrap/buttons';

import { UserProjectsComponent } from './userProjects.component';
import { UserProjectsRoutingModule } from './userProjects-routing.module';

import { CodeChallengeService } from '../../services';

@NgModule({
  imports: [
    FormsModule,
    UserProjectsRoutingModule,
    BsDropdownModule,
    CommonModule,
    ButtonsModule.forRoot()
  ],
  declarations: [ 
    UserProjectsComponent 
  ],
  providers: [CodeChallengeService]
})
export class UserProjectsModule { }
