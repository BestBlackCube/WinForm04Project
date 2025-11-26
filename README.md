# WinForm04Project
### 해당 프로젝트는 WinForm으로 카드게임을 개발하는 조별 과제입니다.

## 프로젝트 4조
WinForm으로 카드게임을 개발하자!

Steam에 출시 되어 있는 인스크립션 [Steam link](https://store.steampowered.com/app/1092790/Inscryption/) 게임의 전투 시스템을 참고하여 만든 게임이며,  
다양한 카드로 필드 전략을 구상하여 상대의 Hp를 전부 소진 시키면 이기는 방식입니다.

### 팀원 담당 파트
- Form 연결 및 관리
- 튜토리얼
- 전투 시스템 알고리즘
- 부가 기능 설정
- UI

### 기술 스택
Visual Studio WinForm C#

# WinForm04 Project 카드 게임 개발 5.5.6v
## 기능 설명
기본 UI 배경 이미지에서 직접 제작한 UI들로 비주얼 업데이트.  
화면 비율 설정을 전체화면/창화면을 사용하지만 PC용 화면과 노트북 등 화면 비율을 다르기 때문에 선택폭을 늘림.  
신속한 게임 플레이를 원하는 플레이어들을 위한 전투 딜레이 제거 기능 추가.



- ## Form01
    - ### [전투 딜레이](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L33-L37)
        - 기존의 전투 딜레이의 기다리는 시간을 On,Off기능을 추가하여 취향에 맞는 전투가 가능하다.
    - ### [화면비율](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L73-L152)
        - 기존의 비율 설정은 전체화면과 창모드를 번갈아 가며 임의대로 조절 하였지만,  
          크기를 지정하여 전체화면과 창모드를 바꿔가는 방식으로 변경.  
          (1920x1080, 1440x900)

- ## 버그
    - ### 메인 화면 화면 비율
        - 메인 화면 설정창 사용시 화면 비율의 고정값으로 인해 버튼이 고정된 값에서 이동하지 않음.
    - ### 튜토리얼
        - 튜토리얼 첫장의 이미지가 버튼을 누르지 않으면 증감값이 들어가지 않은 상태라 기본 화면을 불러옴
    - ### 버리기 버튼
        - 인게임 도중 버리기 기능을 켠 상태로 턴종료 버튼을 누르면 버리기 기능이 활성화 된 상태로 남아있음.
    - ### 설정창
        - 인게임 도중 설정 버튼 클릭시 강제 전체 화면으로 되돌아감.

## 버전 업데이트 지연
```
NA.NA.4v 업데이트 지연
    1.1.0v -> 1.1.1v
    - 마법 카드 사용시 캐릭터 카드에 사용하는 것이 아닌 필드에 소환되는 버그
    - 버리기 기능 사용시 카드가 없어도 없어지는 버그

    2.1.0 -> 2.1.2v 
    - 마법 카드를 사용 할때 필드 소환의 버튼이 남아 있음.
      눌렀을 시 데이터의 변화는 없음
    - 버리기 기능을 켠 상태로 손 패의 버튼이나 필드의 pictureBox를 클릭시 버리기 버튼이 활성화 되지 않음.
    - 턴 종료 시 손패 버튼이나 필드의 pirtureBox를 클릭시 일부분 버튼이 활성화 됨.
    
    2.2.0v -> 2.2.3v
```
## 버전 표기법 (Semantic Versioning)
```
[주 버전].[부 버전].[수 버전]
   0   .   0   .   0

- 주 버전: 하위 호환성이 깨지는 변경
- 부 버전: 하위 호환성 유지하며 기능 추가
- 수 버전: 하위 호환성 유지하며 버그 수정
```

# WinForm04 Project 카드 게임 개발 4.4.5v
## 기능 설명
설정 창을 통해 세부적인 조정이 가능하며, 게임을 처음 접함 플레이어들을 위한 튜토리얼을 개발.  
인게임 중 폰트를 변경이 가능하고, 전체화면, 창 모드 등 부가적 기능을 추가.  
전투 밸런스 추가 및 전투 이펙트 추가.

- ## Form01
    - ### [부가 기능 설정 창](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L146-L150)
        - Form4에 만들어 둔 부가 기능 설정 창을 연결하여 Form4()의 UI와 값을 불러온다.
    - ### [승패 판정 이펙트](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L514-L521)
        - [Graphics 클래스](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L436-L445)를 사용하여 직관적인 네모칸을 만들고, [Pen 클래스](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L451-L452)를 사용하여 승패 판정을 알아 볼 수 있는  
        네모칸 색 변경으로, 시각적 효과를 볼 수 있다.
    - ### [데미지 반감 기능](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L531-L555)
        - 플레이어가 턴 종료 할 경우, 마주보고 있는 카드끼리 전투를 시작하는데 앞서 마주보고 있는 카드의 능력치를   
        비교하여 더큰 값을 가지고 있는 카드는 전체 데미지의 50%만 받는다.  
        (정수 값 계산식을 사용하여 소수점 일 경우 0.5는 소멸 된다 5 / 2 = 2.5 -> 2)
- ## Form03
    - ### [튜토리얼](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form3.cs)
        - 게임에 처음 접하는 플레이어들을 위한 게임 사용 설명서로 설명서의 이미지는  
        Resource에 넣어둔 이미지 파일을 불러와 시각적인 자료를 보여준다.
        - 버튼을 눌렀을때 증감식을 사용하여 정수의 값이 바뀌며 각 값에 맞는 이미지와 설명란이 바뀐다.
- ## Form04
    - ### [설정창](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form4.cs)
        - 부가적 기능을 조절이 가능한 메인 화면이며, 게임 난이도, 튜토리얼, 전체화면/창화면 변경, 폰트 변경 등  
        게임 외적인 부분을 모집하여 제작한 화면이다. 
    - ### [폰트 설정](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L152-L172)
        - 인게임 내부에서 TextBox를 사용한 모든 글자의 폰트를 본인의 취향대로 변경이 가능하다.
    - ### [화면 비율 조절](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form4.cs#L58-L71)
        - Form4 전체화면/창화면의 체크박스 체크 여부의 값을 가져와 Form1에 있는 전체화면 비율과 창 화면 비율을  
        나누어 불러온 값에 맞게 게임 화면의 크기가 변경된다.
    - ### 난이도 설정
        - 이전과 같이 Form2의 화면을 참조하여 중간에 난이도를 재설정 가능하다.
    - ### 튜토리얼
        - 튜토리얼 Form3을 참조하여 언제든지 튜토리얼을 볼 수 있다.
    - ### 화면 비율 조절
        - 체크 박스를 사용하여 전체화면과 창 화면을 언제든지 취향대로 조절 할 수 있다.

- ## 버그
    - ### 난이도 설정 버튼 이외의 클릭
        - 난이도 선택 페이지가 나온 상태로 뒷 배경에 있는 UI 클릭 시 실행 되는 버그
    - ### 빈화면 필드 소환
        - 손패에서 사용이 안된 카드를 클릭후 빈 손패 카드를 클릭 시 빈 카드가 선택되며 필드에 소환이 가능하며,  
        아무 데이터가 없는 빈공간으로 필드가 잠기는 버그

## 버전 업데이트 지연
```
NA.NA.4v 업데이트 지연
    1.1.0v -> 1.1.1v
    - 마법 카드 사용시 캐릭터 카드에 사용하는 것이 아닌 필드에 소환되는 버그
    - 버리기 기능 사용시 카드가 없어도 없어지는 버그

    2.1.0 -> 2.1.2v 
    - 마법 카드를 사용 할때 필드 소환의 버튼이 남아 있음.
      눌렀을 시 데이터의 변화는 없음
    - 버리기 기능을 켠 상태로 손 패의 버튼이나 필드의 pictureBox를 클릭시 버리기 버튼이 활성화 되지 않음.
    - 턴 종료 시 손패 버튼이나 필드의 pirtureBox를 클릭시 일부분 버튼이 활성화 됨.
    
    2.2.0v -> 2.2.3v
```
## 버전 표기법 (Semantic Versioning)
```
[주 버전].[부 버전].[수 버전]
   0   .   0   .   0

- 주 버전: 하위 호환성이 깨지는 변경
- 부 버전: 하위 호환성 유지하며 기능 추가
- 수 버전: 하위 호환성 유지하며 버그 수정
```

# WinForm04 Project 카드 게임 개발 3.3.4v
## 기능 설명
난이도를 만들어, 클리어의 조건을 충족 하는 과정을 세분화 하여 플레이어의 취양을 갖춤 


- ## Form01
    - ### [난이도 설정](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L102-L120)
        - Form2에서 받아온 정수값을 토대로 게임의 난이도가 바뀌는 구조이다.
- ## Form2
    - ### [난이도 버튼](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form2.cs)
        - Form2에서 나오는 화면 버튼 3개에서 각각의 버튼을 누르면 Form1에 넘길 정수값이 설정 된다.

- ## 버그

## 버전 업데이트 지연
```
NA.NA.4v 업데이트 지연
    1.1.0v -> 1.1.1v
    - 마법 카드 사용시 캐릭터 카드에 사용하는 것이 아닌 필드에 소환되는 버그
    - 버리기 기능 사용시 카드가 없어도 없어 지는 버그

    2.1.0 -> 2.1.2v 
    - 마법 카드를 사용 할때 필드 소환의 버튼이 남아 있음.
      눌렀을 시 데이터의 변화는 없음
    - 버리기 기능을 켠 상태로 손 패의 버튼이나 필드의 pictureBox를 클릭시 버리기 버튼이 활성화 되지 않음.
    - 턴 종료 시 손패 버튼이나 필드의 pirtureBox를 클릭시 일부분 버튼이 활성화 됨.
    
    2.2.0v -> 2.2.3v
```
## 버전 표기법 (Semantic Versioning)
```
[주 버전].[부 버전].[수 버전]
   0   .   0   .   0

- 주 버전: 하위 호환성이 깨지는 변경
- 부 버전: 하위 호환성 유지하며 기능 추가
- 수 버전: 하위 호환성 유지하며 버그 수정
```

# WinForm04 Project 카드 게임 개발 2.3.3v
## 기능 설명
마법 카드의 종류는 공격력 증가 단일 카드 였지만 다양성을 위해 공격력 증가와 체력 증가로 나눔

- ## Form01
    - ### [마법카드 종류](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L59-L87)
        - 캐릭터 카드와 동일하게 카드 구조체에 이미지와 능력치를 대입한다.
    - ### [마법카드 추가](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L182-L200)
        - 마법카드는 공격력과 체력 2가지로 나뉘며, 0~9까지의 난수로 0~4: 공격력 5~9: 체력 50:50 비율로 선정 된다.  
    - ### [마법카드 사용](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L631-L650)
        - Magicbool 정수값 구별기로 공격력 카드인지 체력카드인지 중간 과정을 거쳐 각각의 소스 코드로 이동 된다. 


- ## 버그

## 버전 업데이트 지연
```
NA.NA.4v 업데이트 지연
    1.1.0v -> 1.1.1v
    - 마법 카드 사용시 캐릭터 카드에 사용하는 것이 아닌 필드에 소환되는 버그
    - 버리기 기능 사용시 카드가 없어도 없어 지는 버그

    2.1.0 -> 2.1.2v 
    - 마법 카드를 사용 할때 필드 소환의 버튼이 남아 있음.
      눌렀을 시 데이터의 변화는 없음
    - 버리기 기능을 켠 상태로 손 패의 버튼이나 필드의 pictureBox를 클릭시 버리기 버튼이 활성화 되지 않음.
    - 턴 종료 시 손패 버튼이나 필드의 pirtureBox를 클릭시 일부분 버튼이 활성화 됨.
    
    2.2.0v -> 2.2.3v
```
## 버전 표기법 (Semantic Versioning)
```
[주 버전].[부 버전].[수 버전]
   0   .   0   .   0

- 주 버전: 하위 호환성이 깨지는 변경
- 부 버전: 하위 호환성 유지하며 기능 추가
- 수 버전: 하위 호환성 유지하며 버그 수정
```
# WinForm04 Project 카드 게임 개발 2.2.3v
## 기능 설명
카드의 이미지를 직접 제작하여, 이미지에 맞게 UI를 재 배치,  
Form 화면 비율을 전체화면 크기에 맞추어 실행 및 내부의 UI는 고정된 위치 값을 가짐



- ## Form01
    - ### 카드 이미지 업데이트
        - 직접 제작한 카드 이미지를 Create 폴더에 넣어 비쥬얼 스튜디오 Resource 폴더에 대입 한다.
    - ### UI 재배치
        - 기존 능력치를 시각적으로 볼 수 있는 TextBox를 외부에 배치 해 놓았지만, 카드 이미지 내에  
        능력치 칸을 만들어 그곳에 맞는 크기로 조절하여 재배치 함.
    - ### [화면 비율 유지](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L1297-L1336)
        - Form 화면을 임의로 조절 하였을 때 내부 UI의 위치가 크기에 맞게 임의 조절이 되어 내부가  
        무너지는 모습이 보여, UI의 고정된 크기와 위치를 갖고 이동을 막음.

- ## 버그

## 버전 업데이트 지연
```
NA.NA.4v 업데이트 지연
    1.1.0v -> 1.1.1v
    - 마법 카드 사용시 캐릭터 카드에 사용하는 것이 아닌 필드에 소환되는 버그
    - 버리기 기능 사용시 카드가 없어도 없어 지는 버그

    2.1.0 -> 2.1.2v 
    - 마법 카드를 사용 할때 필드 소환의 버튼이 남아 있음.
      눌렀을 시 데이터의 변화는 없음
    - 버리기 기능을 켠 상태로 손 패의 버튼이나 필드의 pictureBox를 클릭시 버리기 버튼이 활성화 되지 않음.
    - 턴 종료 시 손패 버튼이나 필드의 pirtureBox를 클릭시 일부분 버튼이 활성화 됨.
    
    2.2.0v -> 2.2.3v
```
## 버전 표기법 (Semantic Versioning)
```
[주 버전].[부 버전].[수 버전]
   0   .   0   .   0

- 주 버전: 하위 호환성이 깨지는 변경
- 부 버전: 하위 호환성 유지하며 기능 추가
- 수 버전: 하위 호환성 유지하며 버그 수정
```

# WinForm04 Project 카드 게임 개발 2.1.2v
## 기능 설명
마법 카드를 만들어 캐릭터 카드의 능력치를 올려주는 기능을 추가하여 카드의 다양화를 만듦.  
기능 테스트중 발견된 버그 수정.

- ## Form01
    - ### [마법 카드 생성](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L152-L247)
        - CardChoice 정수를 Random.Next()로 변화하여 0~9까지의 난수로 캐랙터 카드와   
        마법 카드의 확률를 구분 짓는다
        - 위에서 정해진 카드는 mycard 정수를 Random.Next()로 변화하여 0~9까지의 난수로 카드 구조체에서   
        알맞는 데이터를 손패 데이터로 옮긴다.
    - ### [마법 카드 사용](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L559-L607)
        - 캐릭터 카드 였을때 (필드 소환)문구를 가지고 있던 버튼을 (사용 하기)로 바꾸어 사용한다
        - 캐릭터 카드일때와 마법 카드일때의 소스코드를 구별하여 카드마다 다른 결과를 불러 오게 한다.
    - ### [buttonTrue_False](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L101=L108)
        - 손패 카드의 클릭여부를 초기화 시키는 함수
    - ### [Card_FieldFull_Fieldnull](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L109-L126)
        - 필드 카드의 캐릭터 카드가 있는지 없는지를 구별하는 함수
    - ### [MagicSpell_AddCard](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L128-L135)
        - 손패에 있는 마법카드를 선택 했을때 필드에 캐릭터 카드가 있는지 없는지 구별하는 함수 

- ## 버그
    - ### 마법카드 기능적 결함
        - 마법 카드를 사용 할 때 필드 소환 하는 버튼이 안사라짐.  
        눌렀을 시 카드의 데이터 변화에는 미치지 않지만 시각적으로 오류로 보임
    - ### 버리기 버튼
        - 버리기 기능을 켠 상태로 손패 버튼이나 필드 pictureBox 클릭시 버리기 버튼이 나오지 않음.
    - ### 턴 종료 버튼
        - 턴 종료 시 손패 버튼이나, 필드 pictureBox 클릭시 필드 소환 하는 버튼이 활성화 됨.

- ## 수정된 버그
    - ### 마법 카드 사용
        - 사용 시 필드 캐릭터와 마법을 판별하여 각각의 다른 방식으로 실행.
    - 버리기 버튼
        - 기능 활성화 시 해당 칸에 카드가 있는지 없는지 판별하는 방식으로 변경.


## 버전 표기법 (Semantic Versioning)
```
[주 버전].[부 버전].[수 버전]
   0   .   0   .   0

- 주 버전: 하위 호환성이 깨지는 변경
- 부 버전: 하위 호환성 유지하며 기능 추가
- 수 버전: 하위 호환성 유지하며 버그 수정
```

# WinForm04 Project 카드 게임 개발 1.1.1v
## 기능 설명
상세 정보 시스템 변경, 마법 카드 사용 테스트 구현, 버그 수정.



- ## Form01
    - ### [마법 카드](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L599-L609)
        - 캐릭터 카드와 똑같이 카드의 이미지와 능력치를 자동으로 정해지고, 마법 카드를  
        캐릭터 카드에 사용되는 문구와 능력치가 증가한다.
        - 미 개발 단계
    - ### double_Click
        - 더블 클릭시 Form2를 열어 카드의 상세 정보를 보여주는 기능을 삭제하고, Form1에 기존   
        TextBox1의 크기를 줄여 하단에 카드의 상세 정보 보여주는 UI를 추가.
    - ### Resources
        - 마법 카드 이미지를 추가하여 다음 작업에 사용할 이미지 저장.
- ## 버그
    - ### 마법카드 사용
        - 마법 카드를 사용 할 때 캐릭터에게 사용 한다는 것이 아닌 마법 카드를 필드 소환 되는 버그
    - ### 버리기 버튼
        - 버리기 기능이 카드가 없어도 사용되는 버그


## 버전 표기법 (Semantic Versioning)
```
[주 버전].[부 버전].[수 버전]
   0   .   0   .   0

- 주 버전: 하위 호환성이 깨지는 변경
- 부 버전: 하위 호환성 유지하며 기능 추가
- 수 버전: 하위 호환성 유지하며 버그 수정
```
# WinForm04 Project 카드 게임 개발 1.0.0v
## 기능 설명
기본적인 전투 페이지를 만들어 카드 이미지, 능력치등을 시각적으로 보여줌으로 게임의 기초를 만든다.



- ## Form01
    - ### [Delay 기능](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L22-L34)
        - DateTime 함수를 만들어 현재 시간과 끝나는 시간을 정하여 끝나는 시간에 도달할 때까지   
        시스템을 지연 시키는 함수이다.  
        기존의 Thead.Sleep과 다르게 UI 이벤트 시스템을 정지 하지 않는다.
    - ### [카드 이미지 (Resources)](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L55-L95)
        - 카드 이미지는 Resources 폴더를 사용하여 이미지를 저장 시킨후 구조체 배열에 등록 시킴과  
        동시에 각각 카드의 능력치를 Random 난수로 정한다.
    - ### [Form1_Click](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L106-L127)
        - 바탕 화면을 클릭 했을 경우에 내가 선택한 카드가 비 선택 카드로 되돌아 간다.
    - ### [HandCardAdd_Button](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L128-L200)
        - 카드 뽑기 버튼을 눌렀을때 플레이어 손패 (button1~button5)에 CardDB에 저장된 카드의  
        이미지와 능력치가 대입된다.
    - ### [Delete_Button](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L201-L258)
        - 카드 버리기 버튼을 눌렀을때 플레이어 손패에 카드가 있다면 버리기 기능이 사용된다.  
            또한 필드에 올린 카드도 버리기가 가능하다.
    - ### [End_Button](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L259-L474)
        - 플레이어 턴이 종료 했다면 적 전투 필드에 각 Random 난수를 통해 적 카드가 필드에 배치되며,  
        서로의 카드가 있는 경우와 없는경우, 한쪽만 있는 경우를 나누어 전투를 거쳐간다.
    - ### [FieldCardAdd_Button](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L474-L874)
        - 플레이어 손패에 있는 카드를 선택후 필드 소환 버튼 (button6~button10)을 클릭하면  
        손패 카드의 데이터가 필드 데이터로 이동한다.
        - CardAdd_button1~5까지는 똑같은 소스 코드
    - ### [Card_Button](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L875-L1094)
        - 플레이어 손패 카드를 선택 했을 때 카드의 정보를 불러오거나, 버리기 기능이 켜져있다면 카드를 버린다.
        - Card_button1~5까지는 똑같은 소스 코드
    - ### [double_Click](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L1099-L1104)
        - 카드를 더블 클릭하게 된다면 카드의 상세 정보가 나온다.
    - ### PictureBox (1-10)
        - 전투 필드 카드 공간이며, 카드의 이미지와 능력치가 시각적으로 보이며,  
        PictureBox에 마우스 클릭값을 인식하는 코드가 있지만 구별감이 없어, 밑에 보조 button을 사용한다.
    - ### button (1-5, 6-10)
        - (1-5)  
        손패 카드 공간이며, 카드의 이미지와 능력치가 시각적으로 보이며,  
        button 클릭했을때 눌림과 누르지않음이 구별되어 있어 플레이어가 선택한 모습이 시각적으로 보인다.
        - (6-10)  
        손패 카드를 전투 필드로 올리는 버튼이며, 손패 카드의 데이터를 전투 필드 데이터로 옮긴다.
    - ### TextBox1
        - 카드의 변경 사항이나 전투 상황을 알리는 Text기반 UI이다.


## 버전 표기법 (Semantic Versioning)
```
[주 버전].[부 버전].[수 버전]
   0   .   0   .   0

- 주 버전: 하위 호환성이 깨지는 변경
- 부 버전: 하위 호환성 유지하며 기능 추가
- 수 버전: 하위 호환성 유지하며 버그 수정
```