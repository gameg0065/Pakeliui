<template>
  <div class="body">
    <h2>Kontaktai</h2>
    <form action="#" class="contact-form" method="post">
      <label for="full-name">Vardas Pavardė</label>
      <input  type="text" name="full-name" id="full-name" placeholder="Vardenis Pavardenis" />
      <label for="email">Elektroninis paštas</label>
      <inputtype="email" name="email" id="email" placeholder="mano@emailas.lt" />
      <label for="phone">Telefono numeris</label>
      <input type="ter" name="phone" id="phone" placeholder="+370-XXX-XXXXX" />
      <label for="city">Miestas</label>
      <select name="city" id="city">
        <option value="Vilnius">Vilnius</option>
        <option value="Kaunas">Kaunas</option>
        <option value="Klaipeda">Klaipeda</option>
        <option value="Taurage">Taurage</option>
        <option value="Kavenskas">Kavenskas</option>
      </select>
      <label for="agenda">Dėstyk savo reikalus čia</label>
      <input  type="text"  name="agenda" id="agenda" placeholder="State your bussiness"/>
      <button class="submit">Siųsti</button>
    </form>
    <img src="https://i1.alfi.lt/21081/76/48.png" alt="map Lietuva, Vilnius, Naugarduko g 141"/>
  </div>
</template>