using System;
using UnityEngine;
using UnityEditor;
using DopplerInteractive.TidyTileMapper.Editors;
using DopplerInteractive.TidyTileMapper.Words;
using DopplerInteractive.TidyTileMapper.LevelGeneration;
using DopplerInteractive.TidyTileMapper.Utility;

public class TidyMazeCreator_Window : EditorWindow
{
	
	public TidyBlockMapCreator mapCreator;
	
	
	[MenuItem("Window/Tidy Maze Maker")]
	public static void Init () {
		TidyMazeCreator_Window maze = EditorWindow.GetWindow(typeof(TidyMazeCreator_Window),false,"Tidy Maze Maker",true) as TidyMazeCreator_Window; 
		
		maze.mapCreator = EditorWindow.GetWindow<MapCreatorWindow>().mapPainter;
	}
	
	void OnEnable(){
		
		if(mapCreator == null){
					
			MapCreatorWindow w = EditorWindow.GetWindow<MapCreatorWindow>();
			this.mapCreator = w.mapPainter;
			
		}
		
	}
	
	void OnGUI(){
		
		DrawPlugin();
		
	}
	
	#region ITTMPlugin implementation
	public void InitializePlugin (DopplerInteractive.TidyTileMapper.Editors.TidyBlockMapCreator mapCreator)
	{
		this.mapCreator = mapCreator;
	}
	
	
	float tileWidth = 1.0f;
	float tileHeight = 1.0f;
	float tileDepth = 1.0f;
	
	int chunkWidth = 5;
	int chunkHeight = 5;
	
	BlockMap.GrowthAxis growthAxis;
	
	int levelGenWidth;
	int levelGenHeight;
	
	string mapCreationMessage = "";
	
	MazeGenerator.MazeType mazeGenerationType;
	
	string newMapName = "";
	
	public void DrawPlugin ()
	{
		GUILayout.Label("Tidy Level Generator");
		
		EditorGUI.indentLevel = 1;
		
		newMapName = EditorGUILayout.TextField("Map Name:",newMapName);
		
		EditorGUILayout.BeginHorizontal();
		
		EditorGUILayout.PrefixLabel(TidyMessages.MAP_CREATOR_TILE_WIDTH);
		
		GUILayout.FlexibleSpace();
		
		tileWidth = EditorGUILayout.FloatField(tileWidth,GUILayout.ExpandWidth(false));
		
		if(tileWidth <= 0.0f){
			tileWidth = 1.0f;
		}
		GUILayout.Space(20.0f);
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal();
		
		EditorGUILayout.PrefixLabel(TidyMessages.MAP_CREATOR_TILE_HEIGHT);
		
		GUILayout.FlexibleSpace();
		
		tileHeight = EditorGUILayout.FloatField(tileHeight,GUILayout.ExpandWidth(false));
		
		if(tileHeight <= 0.0f){
			tileHeight = 1.0f;
		}
		GUILayout.Space(20.0f);
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal();
		
		EditorGUILayout.PrefixLabel(TidyMessages.MAP_CREATOR_TILE_DEPTH);
		
		GUILayout.FlexibleSpace();
		
		tileDepth = EditorGUILayout.FloatField(tileDepth,GUILayout.ExpandWidth(false));
		
		if(tileDepth <= 0.0f){
			tileDepth = 1.0f;
		}
		GUILayout.Space(20.0f);					
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal();
		
		EditorGUILayout.PrefixLabel(TidyMessages.MAP_CREATOR_NEW_MAP_CHUNK_WIDTH);
							
		GUILayout.FlexibleSpace();
		
		chunkWidth = EditorGUILayout.IntField(chunkWidth,GUILayout.ExpandWidth(false));
		
		if(chunkWidth <= 0){
			chunkWidth = 1;
		}
		GUILayout.Space(20.0f);					
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal();
		
		EditorGUILayout.PrefixLabel(TidyMessages.MAP_CREATOR_NEW_MAP_CHUNK_HEIGHT);
							
		GUILayout.FlexibleSpace();
		
		chunkHeight = EditorGUILayout.IntField(chunkHeight,GUILayout.ExpandWidth(false));
		
		if(chunkHeight <= 0){
			chunkHeight = 1;
		}
		GUILayout.Space(20.0f);
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal();
		
		EditorGUILayout.PrefixLabel(TidyMessages.MAP_CREATOR_MAP_GROW_AXIS);
		
		GUILayout.FlexibleSpace();
		
		growthAxis = (BlockMap.GrowthAxis)EditorGUILayout.EnumPopup(growthAxis,GUILayout.ExpandWidth(false));
		GUILayout.Space(20.0f);
		EditorGUILayout.EndHorizontal();
		
		EditorGUI.indentLevel = 0;
		
		EditorGUI.indentLevel = 1;
		
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel(TidyMessages.MAP_CREATOR_LEVEL_GENERATION_WIDTH);
		GUILayout.FlexibleSpace();
		levelGenWidth = EditorGUILayout.IntField(levelGenWidth);
		
		if(levelGenWidth < chunkWidth){
			levelGenWidth = chunkWidth;
		}
		GUILayout.Space(20.0f);
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel(TidyMessages.MAP_CREATOR_LEVEL_GENERATION_HEIGHT);
		GUILayout.FlexibleSpace();
		levelGenHeight = EditorGUILayout.IntField(levelGenHeight);
		
		if(levelGenHeight < chunkHeight){
			levelGenHeight = chunkHeight;
		}
		
		GUILayout.Space(20.0f);
		
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal();
		
		EditorGUILayout.PrefixLabel(TidyMessages.MAP_CREATOR_MAZE_TYPE_LABEL);
		GUILayout.FlexibleSpace();
		mazeGenerationType = (MazeGenerator.MazeType) EditorGUILayout.EnumPopup(mazeGenerationType);
		GUILayout.Space(20.0f);
		EditorGUILayout.EndHorizontal();
		
		GUILayout.FlexibleSpace();
		
		EditorGUILayout.BeginHorizontal();	
	
		GUILayout.FlexibleSpace();
		
		EditorGUI.indentLevel = 0;
		
		if(GUILayout.Button(new GUIContent(TidyMessages.MAP_CREATOR_GENERATE_MAZE,TidyTooltips.MAP_CREATOR_GENERATE_MAZE))){
		
			OrientedBlock workingBlock = mapCreator.GetWorkingBlock();
			
			if(workingBlock == null){
				
				mapCreationMessage = TidyMessages.MAP_CREATOR_NO_BLOCK_CHOSEN;
				
			}
			else
			if(string.IsNullOrEmpty(newMapName)){
				
				mapCreationMessage = TidyMessages.MAP_CREATOR_NO_NAME;
				
			}
			else 
			if(mapCreator.MapNameExists(newMapName)){
				mapCreationMessage = TidyMessages.MAP_CREATOR_NAME_EXISTS;
			}
			else{
				
				mapCreationMessage = TidyMessages.MAP_CREATOR_MAP_CREATED;
				
				GenerateMaze(newMapName, levelGenWidth,levelGenHeight,mazeGenerationType);
				
				newMapName = "";
				
				mapCreator.RefreshExistentBlockMaps();
				
			}
			
		}
		GUILayout.Space(20.0f);
		EditorGUILayout.EndHorizontal();
		
		GUILayout.Label(mapCreationMessage);
		
		GUILayout.Space(10.0f);
					
	}
	
	void GenerateMaze(string mapName, int width, int height, DopplerInteractive.TidyTileMapper.LevelGeneration.MazeGenerator.MazeType mazeType){
				
		GameObject newMap = new GameObject(mapName);
				
		newMapName = "";
		
		mapCreator.SetWorkingBlockNonEmpty();
		
		//Let's align it to face the camera
		if(Camera.main != null){
			
			newMap.transform.position = Camera.main.transform.position + (Camera.main.transform.forward * 10.0f);
			
			newMap.transform.forward = Camera.main.transform.forward * -1;
		}
			
		BlockMap map = newMap.AddComponent<BlockMap>();
		
		map.chunkWidth = chunkWidth;
		map.chunkHeight = chunkHeight;
		map.tileScale = new Vector3(tileWidth,tileHeight,tileDepth);
		map.growthAxis = growthAxis;
		map.editorMap = true;
		
		map.Editor_InitializeMap(mapName,TidyEditorUtility.GetMapChunkPrefab());
		
		//Now we have our map
		
		bool[,] maze = MazeGenerator.GenerateMaze(width,height,mazeType);
					
		int m_width = maze.GetLength(0);
		int m_height = maze.GetLength(1);
		
		int chunksAcross = m_width / map.chunkWidth + 1;
		int chunksUp = m_height / map.chunkHeight + 1;
		
		for(int x = 0; x < chunksAcross; x++){
			
			for(int y = 0; y < chunksUp; y++){
				
				map.Editor_AddChunkAt(x,y,0,TidyEditorUtility.GetMapChunkPrefab(),false);
				
			}
			
		}
		
		for(int x = 1; x <= chunksAcross; x++){
			
			for(int y = 1; y <= chunksUp; y++){
				
				OrientedBlock[] emptyBlocks = new OrientedBlock[map.chunkWidth * map.chunkHeight];
				
				for(int i = 0; i < emptyBlocks.Length; i++){
					//emptyBlocks[i] = EditorUtility.InstantiatePrefab(TidyEditorUtility.GetNullBlock()) as OrientedBlock;
					emptyBlocks[i] = PrefabUtility.InstantiatePrefab(TidyEditorUtility.GetNullBlock()) as OrientedBlock;
				}
				
				map.Editor_InitializeChunkAt(x,y,0,emptyBlocks,TidyEditorUtility.GetMapChunkPrefab());
				
			}
			
		}
											
		for(int x = map.chunkWidth; x < map.chunkWidth + m_width; x++){
			
			for(int y = map.chunkHeight; y < map.chunkHeight + m_height; y++){
				
				int x_c = x-chunkWidth;
				int y_c = y-chunkWidth;
				
				if(maze[x_c,y_c] != true){
					
					Block b = map.GetBlockAt(x,y,0);
					
					if(b != null){
						
						mapCreator.PaintBlock(b,false);
					}
				}
				
			}
			
		}
		
		mapCreator.SetEntireMapDirty(map);
		
	}

	public void DrawScene (SceneView sceneView)
	{
		
	}

	public void UpdatePlugin (float deltaTime)
	{
		
	}

	public void FinalizePlugin ()
	{
		
	}

	public void DeactivateTool ()
	{
		
	}
	#endregion
}


