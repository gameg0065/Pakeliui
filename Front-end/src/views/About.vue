<template>
  <div class="about">
    <div class="body">
      <h2>Apie mus</h2>
      <h4>Kas yra „Pakeliui“?</h4>
      <p>
        Tai lietuviška platforma, skirta visiems, norintiems keliauti kartu su
        pakeleiviais. Projekto idėja gimė iš studentiško gyvenimo patirties.
        Važiavimas tarpmiestiniu transportu gali prailgti, tapti varginančiu bei
        gerokai ištuštinti piniginę. Kelionės kartu su nepažįstamais
        vairuotojais atrodė patogesnė, tačiau mažiau saugi alternatyva. Būtent
        todėl užsibrėžėme tikslą sukurti internetinę platformą, kuri šį
        keliavimo būdą paverstu jaukiu ir saugiu.
      </p>
      <p>
        „Pakeliui" Jums siūlo pigesnį, lengvesnį bei patogesnį keliavimo būdą. Važiavimas kartu su pakeleiviais skirtas ne tik studentams, bet visiems, norintiems iš taško A nukeliauti į tašką B greitai, saugiai ir pigiai. Mūsų komandos sukurta platforma – tarpininkas tarp vairuotojo ir keleivio, užtikrinantis sklandų bendradarbiavimą.
      </p>
      <h4>Mūsų tikslas – užtikrinti keliavimo būdą, kuris būtų:</h4>
      <p>
        <ul>
          <li><strong>Saugus</strong> - visa informacija apie vartotojus bei keliones yra saugoma</li>
          <li><strong>Greitas</strong> - skelbimus norimu laiku rasti padeda platformoje esantys filtrai. </li>
          <li><strong>Pigus</strong> - sutaupyti padeda kelionės kaštų dalijimasis su pakeleiviais.</li>
          <li><strong>Patogus </strong> - platforma leidžia rasti bendrakeleivių visoje Lietuvoje. </li>
          <li><strong>Pilnas galimybių</strong> - pakeliui gali sutikti begalės unikalių žmonių</li>
        </ul>
      </p>
      <h4>„Pakeliui“ komanda </h4>
      <p>
        „Pakeliui“ įkūrėjai – tai jauna komanda, kurią sudaro ambicingi, veržlūs ir nuolat tobulėjantys studentai. Tai yra pelno siekianti organizacija, kurios pagrindinis tikslas – teikti kokybišką pavėžėjimo tarpininkavimo paslaugą. Mūsų komandos vertybes sudaro profesionalumas, kokybė, atsakomybė ir inovatyvumas. 
      </p>

      <div class="profiles">
        <div class="profile">
          <Avatar
            size="big"
            path="https://images.unsplash.com/photo-1476493279419-b785d41e38d8?ixlib=rb-0.3.5&q=80&fm=jpg&crop=faces&fit=crop&h=200&w=200&s=61eaea85f1aa3d065400179c78163f15"
          />
          <p>Aistė Stončiūtė</p>
        </div>

        <div class="profile">
          <Avatar
            size="big"
            path="https://uifaces.co/our-content/donated/FJkauyEa.jpg"
          />
          <p>Ignas Pangonis</p>
        </div>

        <div class="profile">
          <Avatar
            size="big"
            path="https://uifaces.co/our-content/donated/vIqzOHXj.jpg"
          />
          <p>Benjaminas Račas</p>
        </div>

        <div class="profile">
          <Avatar
            size="big"
            path="https://uifaces.co/our-content/donated/1H_7AxP0.jpg"
          />
          <p>Vadimas Kožemiakinas</p>
        </div>

        <div class="profile">
          <Avatar
            size="big"
            path="https://uifaces.co/our-content/donated/Square__small_.jpg"
          />
          <p>Tomas Kvedravičius</p>
        </div>

        <div class="profile">
          <Avatar
            size="big"
            path="https://uifaces.co/our-content/donated/Xp0NB-TL.jpg"
          />
          <p>Tomas Šinkūnas</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
export default {
  name: 'About',
  components: {
    Avatar,
  },
};
</script>
<style lang="scss">
@import '../assets/styles/about-us.css';
</style>
