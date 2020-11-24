<template>
  <div class="about">
    <h2 class="page-title">Apie mus</h2>
    <p>Pakeliui – geresnis būdas keliauti!</p>
    <h4>Kas yra „Pakeliui“?</h4>
    <p>Tai lietuviška platforma, skirta visiems, norintiems keliauti kartu su pakeleiviais</p>
    <p>„Pakeliui“ įkūrėjai – tai jauna komanda, kurią sudaro ambicingi, veržlūs ir nuolat tobulėjantys studentai. Tai yra pelno siekianti organizacija, kurios pagrindinis tikslas – teikti kokybišką pavėžėjimo tarpininkavimo paslaugą. Mūsų komandos vertybes sudaro profesionalumas, kokybė, atsakomybė ir inovatyvumas.</p>
    <p>Projekto idėja gimė iš studentiško gyvenimo patirties. Važiavimas tarpmiestiniu transportu gali prailgti, tapti varginančiu bei gerokai ištuštinti piniginę. Kelionės kartu su nepažįstamais vairuotojais atrodo patogesnė, tačiau mažiau saugi alternatyva. Būtent todėl užsibrėžėme tikslą sukurti internetinę platformą, kuri šį keliavimo būdą paverstų jaukiu ir visiškai saugiu.</p>
    <p>„Pakeliui" Jums siūlo pigesnį, lengvesnį bei patogesnį keliavimo būdą. Važiavimas kartu su pakeleiviais skirtas ne tik studentams, bet visiems, norintiems iš taško A nukeliauti į tašką B greitai, saugiai ir pigiai. Mūsų komandos sukurta platforma – tarpininkas tarp vairuotojo ir keleivio, užtikrinantis sklandų bendradarbiavimą. Mūsų tikslas – užtikrinti keliavimo būdą, kuris būtų:</p>
    <ul>
      <li><strong>Saugus</strong> - visa informacija apie vartotojus bei keliones yra saugoma.</li>
      <li><strong>Greitas</strong> - skelbimus norimu laiku rasti padeda platformoje esantys filtrai.</li>
      <li><strong>Pigus</strong> - sutaupyti padeda kelionės kaštų dalijimasis su pakeleiviais.</li>
      <li><strong>Patogus </strong> - platforma leidžia rasti bendrakeleivių visoje Lietuvoje.</li>
      <li><strong>Pilnas galimybių</strong> - pakeliui gali sutikti begales unikalių žmonių</li>
    </ul>

    <h4>„Pakeliui“ komanda:</h4>

    <div class="profiles">
      <div class="profile">
        <Avatar
          size="big"
          :path="require('../assets/images/team/aiste-stonciute.png')"
        />
        <p>Aistė Stončiūtė</p>
      </div>

      <div class="profile">
        <Avatar
          size="big"
          :path="require('../assets/images/team/benjaminas-racas.png')"
        />
        <p>Benjaminas Račas</p>
      </div>

      <div class="profile">
        <Avatar
          size="big"
          :path="require('../assets/images/team/ignas-pangonis.png')"
        />
        <p>Ignas Pangonis</p>
      </div>

      <div class="profile">
        <Avatar
          size="big"
          :path="require('../assets/images/team/tomas-kvedaravicius.png')"
        />
        <p>Tomas Kvedravičius</p>
      </div>

      <div class="profile">
        <Avatar
          size="big"
          :path="require('../assets/images/team/tomas-sinkunas.png')"
        />
        <p>Tomas Šinkūnas</p>
      </div>

      <div class="profile">
        <Avatar
          size="big"
          :path="require('../assets/images/team/vadimas-kozemiakinas.png')"
        />
        <p>Vadimas Kožemiakinas</p>
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
@import '../assets/styles/about.scss';
</style>
