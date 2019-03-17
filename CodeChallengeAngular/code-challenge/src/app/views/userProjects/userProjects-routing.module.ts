import { NgModule } from '@angular/core';
import { Routes,
     RouterModule } from '@angular/router';

import { UserProjectsComponent } from './userProjects.component';

const routes: Routes = [
  {
    path: '',
    component: UserProjectsComponent,
    data: {
      title: 'User Projects'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserProjectsRoutingModule {}
