## Deadline
- [ ] preferowany: `2024-02-03`
- [ ] ostateczny: `2024-02-15`

</br>

## Gameplay
- [x] gaśnica po lewej, płonący przedmiot po prawej
- [x] klik na zawkleczkę -> animacja odbezpieczenia gaśnicy
  - [x] zawleczka upada na podłogę
- [x] klik na dyszę -> animacja ustawienia się dyszy
- [x] klik na uchwyt -> gaszenie
  - [ ] proszek wylatuje tak długo jak przycisk jest trzymany
  - [x] proszku wystarcza na 10 sekund ciągłego gaszenia
- [x] gaszenie zmniejsza wielkość ognia
  - [x] ogień wymaga 6 sekund ciągłego gaszenia
  - [x] wielkość ognia zwiększa się gdy nie jest gaszonny

</br>

## UI
- [ ] pozycja Y gaśnicy (lub dyszy?)
- [ ] ilość proszku w gaśnicy
- [ ] wielkość ognia 
- [ ] wskazówki co robić dalej

</br>

## Dodatkowe informacje
- [x] Wersja Unity: `2022.3.14f1`
- [x] Render pipeline: `Built-in`
- [ ] dźwięki
- [x] wąż pomiędzy dyszą a gaśnicą -> `LineRenderer`
- [x] efekty proszku gaśniczy i ognia -> `ParticleSystem`

</br>

## Brak
- [x] kontroli kamerą
- [x] postaci
- [x] zewnętrznych paczek
- [x] zewnętrznych assetów (poza dzwiękami)

</br>

## Dostarczenie
- [ ] .unitypackage (scena z wszystkimi zależnościami)
- [ ] orientacyjny czas pracy

</br>

## Załączniki
- <details><summary>Treść maila</summary>
  
  > Treść zadania:  
  > - Gaśnica stoi naprzeciwko przedmiotu, który się pali. Po kliknięciu na zawleczkę ma uruchamiać się animacja odbezpieczenia gaśnicy po wykonaniu której zawleczka ma spaść na podłogę. Następnie gracz ma kliknąć na dyszę, co uruchomi animację ustawienia się dyszy przed gaśnicą na wprost. Teraz gracz może kliknąć na rączkę aby rozpocząć gaszenie. Dopóki trzyma lewy przycisk myszy z gaśnicy wylatuje proszek. Ogień ma być możliwy do zgaszenia, jeżeli gracz dobrze ustawi gaśnicę (6s gaszenia gaśnica ma zgasić ogień). Ogień się "zmniejsza" gdy jest gaszony i powoli zwiększa gdy przestaje być gaszony
  
  > Co ma się znaleźć na UI:
  > - suwak regulujący wysokość gaśnicy względem ognia
  > - pokazać ile pozostało proszku w gaśnicy (proszek gaśniczy w gaśnicy starcza na 10 sekund gaszenia po czym się kończy)
  > - moc / poziom “życia“ ognia
  
  > Dodatkowe informacje:
  > - użyj zwykłego środowiska 3D (nie URP), kamera ma być statyczna (bez żadnego systemu sterowania graczem/kamerą), ustawiona na widok z boku (jak w grach 2D) gaśnica ma być widoczna po lewej stronie, a płonący obiekt po prawej 
  > - zapewnij graczowi klarowne wskazówki dotyczące kroków, które musi wykonać w danej chwili
  > - dodaj jakieś podstawowe dźwięki
  > - użyj line renderera do zrobienia węża pomiędzy dyszą a gaśnicą
  > - do zobrazowania ognia, oraz proszku gaśniczego należy wykorzystać podstawowy system particli (unitypackage ma być możliwie mały)
  > - użyj gaśnicy dostępnej pod tym linkiem: https://drive.google.com/file/d/1fVVRtl9SbTkwhmgHS3JEqX1Wk7VPVjwV/view?usp=sharing
  > - rozwiązania wyeksportować jako .unitypackage (scena z wszystkimi zależnościami)
  > - nie dodawać żadnych tekstur, assetów (poza dźwiękami), zewnętrznych paczek
  
  > Zadanie proszę wykonać w 3D (zwykłym nie URP), w Unity w wersji 2020, 2021 lub 2022 ale nie większej niż 2022.3.14.
  
  > W odpowiedzi na tego maila proszę o wysłanie:
  > - rozwiązania w formie .unitypackage
  > - orientacyjnego czasu jaki zadanie zajęło
  </details>
- <details><summary>Model gaśnicy</summary>

  > - https://drive.google.com/file/d/1fVVRtl9SbTkwhmgHS3JEqX1Wk7VPVjwV
</details>
