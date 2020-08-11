import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatTooltipModule } from '@angular/material/tooltip';
import { HeaderComponent } from './header/header.component';
import { TileComponent } from './tile/tile.component';
import { SubmitButtonComponent } from './submit-button/submit-button.component';
import { ActivitytileComponent } from './activitytile/activitytile.component';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    TileComponent,
    HeaderComponent,
    SubmitButtonComponent,
    ActivitytileComponent,
  ],
  imports: [
    CommonModule,
    MatIconModule,
    MatButtonModule,
    MatMenuModule,
    MatTooltipModule,
  ],
  exports: [
    TileComponent,
    HeaderComponent,
    SubmitButtonComponent,
    ActivitytileComponent,
  ],
})
export class SharedModule {}
