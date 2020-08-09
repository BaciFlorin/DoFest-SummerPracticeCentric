import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatMenuModule} from '@angular/material/menu';
import {MatTooltipModule} from '@angular/material/tooltip';
import { HeaderComponent } from './header/header.component';
import { TileComponent } from './tile/tile.component';
import {SubmitButtonComponent} from "./submit-button/submit-button.component"

@NgModule({
  declarations: [TileComponent, HeaderComponent, SubmitButtonComponent],
  imports: [CommonModule, MatIconModule, MatButtonModule, MatMenuModule, MatTooltipModule],
  exports: [TileComponent, HeaderComponent, SubmitButtonComponent]
})
export class SharedModule {}
