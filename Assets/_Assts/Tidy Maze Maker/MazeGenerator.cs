using System;
using UnityEngine;
using System.Collections.Generic;

namespace DopplerInteractive.TidyTileMapper.LevelGeneration
{
	public class MazeGenerator
	{
		public enum MazeType{
			RecursiveBacktracker,
			Prims
		}
		
		public class MazeCell{
			
			public bool upperWall = true;
			public bool lowerWall = true;
			public bool leftWall = true;
			public bool rightWall = true;
			
			public bool visited = false;
			
			public int x;
			public int y;
			
			public MazeCell(int x, int y){
				this.x = x;
				this.y = y;
			}
			
			public override bool Equals (object obj)
			{
				MazeCell m = obj as MazeCell;
				
				if(m == null){
					return false;
				}
				
				return (m.x == x && m.y == y);
			}
			
			public override int GetHashCode ()
			{
				return base.GetHashCode ();
			}
			
		}
		
		
		public static bool[,] GenerateMaze(int width, int height, MazeType mazeType){
			
			switch(mazeType){
				
				case MazeType.RecursiveBacktracker:{
				
					return GenerateRecursiveBacktrack(width,height);
				
				}
				
				case MazeType.Prims:{
				
					return GeneratePrims(width,height);
				
				}
			}
			
			return null;
			
		}
		
		static bool[,] GeneratePrims(int width, int height){
			
			MazeCell[,]	workingMaze = new MazeCell[width,height];
			
			for(int x = 0; x < width; x++){
				for(int y = 0; y < height; y++){
					workingMaze[x,y] = new MazeGenerator.MazeCell(x,y);
				}
			}
			
			int sx = UnityEngine.Random.Range(0,width);
			int sy = UnityEngine.Random.Range(0,height);
			
			MazeCell currentCell = workingMaze[sx,sy];
			
			currentCell.visited = true;
			
			List<MazeCell> frontier = GetAvailableCells(currentCell,workingMaze);
			
			while(frontier.Count > 0){
				
				int index = UnityEngine.Random.Range(0,frontier.Count);
				
				MazeCell selected = frontier[index];
				
				frontier.RemoveAt(index);
				
				selected.visited = true;
				
				List<MazeCell> newFrontier = GetAvailableCells(selected,workingMaze);
				
				for(int i = 0; i < newFrontier.Count; i++){
					if(!frontier.Contains(newFrontier[i])){
						frontier.Add(newFrontier[i]);
					}
				}
				
				List<MazeCell> attached = GetUnAvailableCells(selected,workingMaze);
								
				MazeCell attachToCell = attached[UnityEngine.Random.Range(0,attached.Count)];
				
				if(attachToCell.x > selected.x){
					selected.rightWall = false;
				} 
				else if(attachToCell.x < selected.x){
					selected.leftWall = false;
				}
				else if(attachToCell.y > selected.y){
					selected.lowerWall = false;
				}
				else if(attachToCell.y < selected.y){
					selected.upperWall = false;
				}
					
				
			}
			
			bool[,] maze = new bool[width+width+1,height+height+1];
						
			for(int x = 1, mx = 0; mx < width; x += 2, mx++){
				
				for(int y = 1, my = 0; my < height; y += 2, my++){
					
					maze[x,y] = true;
					
					MazeCell cell = workingMaze[mx,my];
					
					if(!cell.upperWall){
						maze[x,y-1] = true;
					}
					
					if(!cell.lowerWall){
						maze[x,y+1] = true;
					}
					
					if(!cell.leftWall){
						maze[x-1,y] = true;
					}
					
					if(!cell.rightWall){
						maze[x+1,y] = true;
					}
					
				}
			}
			
			return maze;
		}
		
		static bool[,] GenerateRecursiveBacktrack(int width, int height){
			
			MazeCell[,]	workingMaze = new MazeCell[width,height];
			
			for(int x = 0; x < width; x++){
				for(int y = 0; y < height; y++){
					workingMaze[x,y] = new MazeGenerator.MazeCell(x,y);
				}
			}
			
			//1) Choose a starting point in the field.
			//2) Randomly choose a wall at that point and carve a passage through 
			//to the adjacent cell, but only if the adjacent cell has not been visited yet. This becomes the new current cell.
			//3) If all adjacent cells have been visited, back up to the last cell that has uncarved walls and repeat.
			//4) The algorithm ends when the process has backed all the way up to the starting point.
			
			int sx = UnityEngine.Random.Range(0,width);
			int sy = UnityEngine.Random.Range(0,height);
			
			MazeCell currentCell = workingMaze[sx,sy];
			
			workingMaze = PopulateRecursiveBacktrackMaze(currentCell,workingMaze);
			
			bool[,] maze = new bool[width+width+1,height+height+1];
						
			for(int x = 1, mx = 0; mx < width; x += 2, mx++){
				
				for(int y = 1, my = 0; my < height; y += 2, my++){
					
					maze[x,y] = true;
					
					MazeCell cell = workingMaze[mx,my];
					
					if(!cell.upperWall){
						maze[x,y-1] = true;
					}
					
					if(!cell.lowerWall){
						maze[x,y+1] = true;
					}
					
					if(!cell.leftWall){
						maze[x-1,y] = true;
					}
					
					if(!cell.rightWall){
						maze[x+1,y] = true;
					}
					
				}
			}
			
			return maze;
			
		}
		
		static MazeCell[,] PopulateRecursiveBacktrackMaze(MazeCell currentCell, MazeCell[,] workingMaze){
			
			currentCell.visited = true;
			
			List<MazeCell> availableCells = GetAvailableCells(currentCell,workingMaze);
			
			if(availableCells.Count == 0){
				return workingMaze;
			}
			
			availableCells = ShuffleCellList(availableCells);
						
			for(int i = 0; i < availableCells.Count; i++){
				
				MazeCell cell = workingMaze[availableCells[i].x,availableCells[i].y];
				
				if(!cell.visited){
					
					//carve the thing out
					if(currentCell.x < availableCells[i].x){
						currentCell.rightWall = false;
					}
					else
					if(currentCell.x > availableCells[i].x){
						currentCell.leftWall = false;
					}
					else if(currentCell.y < availableCells[i].y){
						currentCell.lowerWall = false;
					}
					else
					if(currentCell.y > availableCells[i].y){
						currentCell.upperWall = false;
					}
					
					PopulateRecursiveBacktrackMaze(availableCells[i],workingMaze);
					
				}
				
			}
			                                             
			
			return workingMaze;
			
			
		}
		
		static List<MazeCell> ShuffleCellList(List<MazeCell> cellList){
			
			List<MazeCell> shuffledList = new List<MazeCell>();
			
			while(cellList.Count > 0){
				
				int index = UnityEngine.Random.Range(0,cellList.Count);
				
				shuffledList.Add(cellList[index]);
				cellList.RemoveAt(index);
				
			}
			
			return shuffledList;
			
		}
				                          
		static List<MazeCell> GetAvailableCells(MazeCell currentCell, MazeCell[,] map){
			
			int ux = currentCell.x+1;
			int dx = currentCell.x-1;
			int uy = currentCell.y-1;
			int dy = currentCell.y+1;
			
			List<MazeCell> availableCells = new List<MazeCell>();
			
			int y = currentCell.y;
			int x = currentCell.x;
			
			if(ux >= 0 && ux < map.GetLength(0) && !map[ux,y].visited){
				availableCells.Add(map[ux,y]);
			}
			
			if(uy >= 0 && uy < map.GetLength(1) && !map[x,uy].visited){
				availableCells.Add(map[x,uy]);
			}
			
			if(dx >= 0 && dx < map.GetLength(0) && !map[dx,y].visited){
				availableCells.Add(map[dx,y]);
			}
			
			if(dy >= 0 && dy < map.GetLength(1) && !map[x,dy].visited){
				availableCells.Add(map[x,dy]);
			}
			
			return availableCells;
		}
		
		static List<MazeCell> GetUnAvailableCells(MazeCell currentCell, MazeCell[,] map){
			
			int ux = currentCell.x+1;
			int dx = currentCell.x-1;
			int uy = currentCell.y-1;
			int dy = currentCell.y+1;
			
			List<MazeCell> unavailableCells = new List<MazeCell>();
			
			int y = currentCell.y;
			int x = currentCell.x;
			
			if(ux >= 0 && ux < map.GetLength(0) && map[ux,y].visited){
				unavailableCells.Add(map[ux,y]);
			}
			
			if(uy >= 0 && uy < map.GetLength(1) && map[x,uy].visited){
				unavailableCells.Add(map[x,uy]);
			}
			
			if(dx >= 0 && dx < map.GetLength(0) && map[dx,y].visited){
				unavailableCells.Add(map[dx,y]);
			}
			
			if(dy >= 0 && dy < map.GetLength(1) && map[x,dy].visited){
				unavailableCells.Add(map[x,dy]);
			}
			
			return unavailableCells;
		}
		
		static bool[] GetVisitedState(MazeCell currentCell, MazeCell[,] map){
			
			int ux = currentCell.x+1;
			int dx = currentCell.x-1;
			int uy = currentCell.y+1;
			int dy = currentCell.y-1;
			
			//up down left right
			bool[] state = new bool[4];
			state[0] = true;
			state[1] = true;
			state[2] = true;
			state[3] = true;
						
			if(ux > 0 && ux < map.GetLength(0)){
				state[3] = map[ux,currentCell.y].visited;
			}
			
			if(uy > 0 && uy < map.GetLength(1)){
				state[0] = map[currentCell.x,uy].visited;
			}
			
			if(dx > 0 && dx < map.GetLength(0)){
				state[2] = map[dx,currentCell.y].visited;
			}
			
			if(dy > 0 && dy < map.GetLength(1)){
				state[1] = map[currentCell.x,dy].visited;
			}
			
			return state;
			
		}
		
		
	}
}


