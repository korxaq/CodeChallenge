import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { CodeChallengeService } from '../../services'
import { User, UserProjectCalculated } from '../../models';
import { takeWhile } from 'rxjs/operators';

@Component({
  templateUrl: './userProjects.component.html',
  styleUrls: ['./userProjects.component.scss'],
})

export class UserProjectsComponent implements OnInit {

  active = true;
  userSelected:User;
  users: Array<User>;
  userProjects: Array<UserProjectCalculated>;
  errorMessage:string;
  sectionTitle = 'User Projects';

  constructor(private codeChallengeService: CodeChallengeService) {}

  ngOnInit(): void {
    this.getAllUsers();
  }

  getAllUsers(): void {
    try {
      this.codeChallengeService.getAllUsers()
        .pipe(takeWhile(() => this.active))
        .subscribe( response => {
          this.users = response;
      },
      error => {
        this.errorMessage = error;
      });
    }
    catch (e) {
      this.errorMessage = e;
    }
  }

  getUserProjects(userId:number): void {
    try {
      this.codeChallengeService.getUserProjects(userId).pipe(takeWhile(() => this.active)).subscribe( response => {
        this.userProjects = response;
      },
      error => {
        this.errorMessage = error;
      });
    }
    catch (e) {
      this.errorMessage = e;
    }
  }

}
